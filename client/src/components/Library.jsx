import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { fetchBooks, deleteBook } from "../managers/bookManager";
import { BookCard } from "./books/bookCard";
import "./Library.css";
import "./books/BookCard.css";
import { Row } from "reactstrap";

export const Library = ({ loggedInUser }) => {
  const [books, setBooks] = useState([]); // Holds all books
  const [searchQuery, setSearchQuery] = useState(""); // Search input state
  const [filteredBooks, setFilteredBooks] = useState([]); // Filtered books based on search
  const navigate = useNavigate();

  useEffect(() => {
    // If the user is not logged in, redirect to the login page
    if (!loggedInUser) {
      navigate("/login");
      return; // Exit the effect early if no logged-in user
    }

    // Fetch the logged-in user's books from the backend using the manager
    const loadBooks = async () => {
      try {
        const booksData = await fetchBooks();
        setBooks(booksData);
        setFilteredBooks(booksData); // Initially set filtered books to all books
      } catch (error) {
        console.error("Error fetching books:", error);
      }
    };

    loadBooks();
  }, [loggedInUser, navigate]);

  // Function to navigate to the new book form
  const navigateToNewBookForm = () => {
    navigate("/new-book");
  };

  // Function to handle deleting a book
  const handleDeleteBook = async (bookId) => {
    try {
      await deleteBook(bookId);

      // Remove the deleted book from the state
      setBooks((prevBooks) => prevBooks.filter((book) => book.id !== bookId));
      setFilteredBooks((prevBooks) =>
        prevBooks.filter((book) => book.id !== bookId)
      );
    } catch (error) {
      console.error("Error deleting book:", error);
    }
  };

  // Handle search input change
  const handleSearchChange = (event) => {
    const query = event.target.value;
    setSearchQuery(query);

    // Filter books based on title, genre, or authors
    const filtered = books.filter(
      (book) =>
        book.title.toLowerCase().includes(query.toLowerCase()) || // Search by title
        book.genreName.toLowerCase().includes(query.toLowerCase()) || // Search by genre
        book.authors.some(
          (author) => author.name.toLowerCase().includes(query.toLowerCase()) // Search by author name
        )
    );
    setFilteredBooks(filtered);
  };

  // Render the component
  return (
    <div className="library-container w-screen mt-5">
      <h2>Your Library</h2>

      {/* Search bar */}
      <div className="search-container">
        <input
          type="text"
          className="search-bar"
          placeholder="Search by title, genre, or author..."
          value={searchQuery}
          onChange={handleSearchChange}
        />
      </div>

      {/* Button to navigate to the book creation form */}
      <button className="new-book-button" onClick={navigateToNewBookForm}>
        Add New Book
      </button>

      {filteredBooks.length === 0 ? (
        <p>No books found for your search!</p>
      ) : (
        <>
          {filteredBooks.map((book) => (
            <Row className="my-2" key={book.id}>
              <BookCard book={book} onDelete={handleDeleteBook} />
            </Row>
          ))}
        </>
      )}
    </div>
  );
};

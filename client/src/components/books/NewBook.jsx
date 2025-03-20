import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { createBook } from "../../managers/bookManager"; // Ensure you have a createBook function
import { fetchGenres } from "../../managers/genreManager";
import "./NewBook.css";

export const NewBook = () => {
  const navigate = useNavigate();
  const [book, setBook] = useState({
    title: "",
    description: "",
    condition: "New",
    isbn: "",
    genreId: 1,
    authors: [],
    imageUrl: "", // Add imageUrl field
  });
  const [genres, setGenres] = useState([]);
  const [authorInput, setAuthorInput] = useState("");
  const [authorsList, setAuthorsList] = useState([]);

  useEffect(() => {
    // Load the genres
    const loadGenres = async () => {
      try {
        const genreData = await fetchGenres();
        setGenres(genreData);
      } catch (error) {
        console.error("Error fetching genres:", error);
      }
    };

    loadGenres();
  }, []);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setBook((prevBook) => ({
      ...prevBook,
      [name]: value,
    }));
  };

  const handleAuthorChange = (e) => {
    setAuthorInput(e.target.value);
  };

  const handleAddAuthor = () => {
    if (authorInput.trim() !== "") {
      const newAuthor = {
        Id: 0, // New author ID is 0 since it doesn't exist yet
        Name: authorInput.trim(),
      };

      setAuthorsList((prevAuthors) => [...prevAuthors, newAuthor]);
      setAuthorInput(""); // Clear the input field after adding
    }
  };

  const handleRemoveAuthor = (author) => {
    setAuthorsList((prevAuthors) => prevAuthors.filter((a) => a !== author));
  };

  const fetchBookByISBN = async (isbn) => {
    try {
      const response = await fetch(
        `https://www.googleapis.com/books/v1/volumes?q=isbn:${isbn}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (response.ok) {
        const data = await response.json();
        if (data.totalItems > 0) {
          const bookData = data.items[0].volumeInfo;
          const imageUrl = bookData.imageLinks
            ? bookData.imageLinks.thumbnail
            : null;

          // Populate the form with the fetched data
          setBook({
            ...book,
            title: bookData.title,
            description: bookData.description,
            condition: "New", // Set default condition
            isbn: isbn,
          });

          // Set authors list
          setAuthorsList(
            bookData.authors.map((author) => ({
              Id: 0, // Default ID for authors from Google Books API
              Name: author,
            }))
          );

          // Set the image URL if available
          if (imageUrl) {
            setBook((prevBook) => ({
              ...prevBook,
              imageUrl: imageUrl, // Add image URL to state
            }));
          }
        } else {
          alert("No book found with this ISBN.");
        }
      } else {
        alert("Error fetching book data.");
      }
    } catch (error) {
      console.error("Error fetching book by ISBN:", error);
      alert("An error occurred while fetching the book data.");
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Show confirmation dialog
    const isConfirmed = window.confirm(
      "Are you sure you want to save this book?"
    );

    if (isConfirmed) {
      try {
        const selectedGenre = genres.find((genre) => genre.id === book.genreId);
        const newBook = await createBook({
          ...book,
          genreName: selectedGenre ? selectedGenre.name : "",
          authors: authorsList,
          imageUrl: book.imageUrl, // Include imageUrl when creating the book
        });

        if (newBook) {
          navigate(`/book/${newBook.id}`); // Redirect to the book details page after creation
        } else {
          alert("Failed to add book");
        }
      } catch (error) {
        console.error("Error adding book:", error);
        alert("An error occurred while adding the book.");
      }
    }
  };

  return (
    <div className="new-book-container mt-5 text-start">
      <h2>Add New Book</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="title">Title</label>
          <input
            type="text"
            id="title"
            name="title"
            value={book.title}
            onChange={handleInputChange}
            required
          />
        </div>

        <div>
          <label htmlFor="isbn">ISBN</label>
          <input
            type="text"
            id="isbn"
            name="isbn"
            value={book.isbn}
            onChange={handleInputChange}
            required
          />
          <button
            type="button"
            className="btn"
            onClick={() => fetchBookByISBN(book.isbn)}
          >
            Fetch Book Data
          </button>
        </div>

        <div>
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            name="description"
            value={book.description}
            onChange={handleInputChange}
            required
          />
        </div>

        <div>
          <label htmlFor="condition">Condition</label>
          <select
            id="condition"
            name="condition"
            value={book.condition}
            onChange={handleInputChange}
            required
          >
            <option value="New">New</option>
            <option value="Good">Good</option>
            <option value="Worn">Worn</option>
            <option value="Fair">Fair</option>
          </select>
        </div>

        <div>
          <label htmlFor="genreId">Genre</label>
          <select
            id="genreId"
            name="genreId"
            value={book.genreId}
            onChange={handleInputChange}
            required
          >
            {genres.length > 0 ? (
              genres.map((genre) => (
                <option key={genre.id} value={genre.id}>
                  {genre.name}
                </option>
              ))
            ) : (
              <option value="">Loading genres...</option>
            )}
          </select>
        </div>

        {/* Image Section */}
        <div>
          <label htmlFor="imageUrl">Image URL</label>
          <input
            type="text"
            id="imageUrl"
            name="imageUrl"
            value={book.imageUrl}
            onChange={handleInputChange}
            placeholder="Enter image URL"
          />
          {book.imageUrl && (
            <div>
              <h4>Current Image:</h4>
              <img src={book.imageUrl} alt="Book" style={{ width: "100px" }} />
            </div>
          )}
        </div>

        {/* Authors Section */}
        <div>
          <label htmlFor="authors">Authors</label>
          <input
            type="text"
            id="authors"
            name="authors"
            value={authorInput}
            onChange={handleAuthorChange}
            placeholder="Enter author names"
          />
          <button type="button" onClick={handleAddAuthor}>
            Add Author
          </button>

          <div>
            <h4>Authors List</h4>
            <ul>
              {authorsList.length > 0 ? (
                authorsList.map((author, index) => (
                  <li key={index}>
                    {author.Name}{" "}
                    <button
                      type="button"
                      onClick={() => handleRemoveAuthor(author)}
                    >
                      Remove
                    </button>
                  </li>
                ))
              ) : (
                <p>No authors added yet.</p>
              )}
            </ul>
          </div>
        </div>

        <button type="submit">Add Book</button>
      </form>
    </div>
  );
};

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
    condition: "New", // Set a default condition
    isbn: "", // Add the ISBN field to the state
    genreId: 1, // Set a default Genre ID
    authors: [], // Array to store authors as objects with Id, Name, Bio
  });
  const [genres, setGenres] = useState([]); // State to hold genres
  const [authorInput, setAuthorInput] = useState(""); // State for the input field where authors are typed
  const [authorsList, setAuthorsList] = useState([]); // State to hold the list of authors added

  useEffect(() => {
    // Load the genres
    const loadGenres = async () => {
      try {
        const genreData = await fetchGenres(); // Fetch genres using the genreManager
        setGenres(genreData); // Set genres to state
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
        Bio: "", // You could allow the user to add a bio if needed
      };

      // Add author to the list if not empty
      setAuthorsList((prevAuthors) => [...prevAuthors, newAuthor]);
      setAuthorInput(""); // Clear the input field after adding
    }
  };

  const handleRemoveAuthor = (author) => {
    setAuthorsList((prevAuthors) => prevAuthors.filter((a) => a !== author));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Show confirmation dialog
    const isConfirmed = window.confirm(
      "Are you sure you want to save this book?"
    );

    if (isConfirmed) {
      try {
        // Add genreName here if required by backend
        const selectedGenre = genres.find((genre) => genre.id === book.genreId); // Assuming you have a genres list
        const newBook = await createBook({
          ...book,
          genreName: selectedGenre ? selectedGenre.name : "", // Add genreName
          authors: authorsList, // Include the list of authors (as objects) in the create
        });

        if (newBook) {
          // Only redirect if the book was successfully created
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
    <div className="new-book-container">
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
                <p>No authors added yet.</p> // Optionally handle empty authors list
              )}
            </ul>
          </div>
        </div>

        <button type="submit">Add Book</button>
      </form>
    </div>
  );
};

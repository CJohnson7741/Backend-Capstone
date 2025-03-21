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
    genreIds: [], // Now an array to handle multiple genres
    authors: [],
    imageUrl: "",
  });
  const [genres, setGenres] = useState([]);
  const [authorInput, setAuthorInput] = useState("");
  const [authorsList, setAuthorsList] = useState([]);

  useEffect(() => {
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

          // Map Google Categories to GenreIds
          const newGenres = bookData.categories
            ? bookData.categories.map((category) => {
                const genre = genres.find((g) => g.name === category);
                // If the genre doesn't exist, add it to the list dynamically
                if (!genre) {
                  const newGenre = {
                    id: genres.length + 1, // You can generate the ID however needed
                    name: category,
                  };
                  setGenres((prevGenres) => [...prevGenres, newGenre]); // Add new genre to list
                  return newGenre.id; // Assign the new genre's ID
                }
                return genre.id; // If genre exists, use its ID
              })
            : [];

          // Populate the form with the fetched data
          setBook({
            ...book,
            title: bookData.title,
            description: bookData.description,
            condition: "New",
            isbn: isbn,
            genreIds: newGenres, // Set genreIds based on Google Categories
          });

          // Set authors list
          setAuthorsList(
            bookData.authors
              ? bookData.authors.map((author) => ({
                  Id: 0, // Default ID for authors from Google Books API
                  Name: author,
                }))
              : []
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
        // Get genre names based on the selected genre IDs
        const genreNames = book.genreIds.map((genreId) => {
          const genre = genres.find((g) => g.id === genreId);
          return genre ? genre.name : null;
        });

        // Send the updated book object to the backend, passing both genreIds and genreNames
        const newBook = await createBook({
          ...book,
          authors: authorsList,
          imageUrl: book.imageUrl,
          genreIds: book.genreIds,
          genreName: genreNames[0], // Add genreNames to the payload
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
          <label htmlFor="genreIds">Genres</label>
          <div>
            {genres.length > 0 ? (
              genres.map((genre) => (
                <div key={genre.id}>
                  <label>
                    <input
                      type="checkbox"
                      name="genreIds"
                      value={genre.id}
                      checked={book.genreIds.includes(genre.id)}
                      onChange={(e) => {
                        const selectedGenreId = parseInt(e.target.value);
                        setBook((prevBook) => ({
                          ...prevBook,
                          genreIds: e.target.checked
                            ? [...prevBook.genreIds, selectedGenreId]
                            : prevBook.genreIds.filter(
                                (id) => id !== selectedGenreId
                              ),
                        }));
                      }}
                    />
                    {genre.name}
                  </label>
                </div>
              ))
            ) : (
              <p>Loading genres...</p>
            )}
          </div>
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

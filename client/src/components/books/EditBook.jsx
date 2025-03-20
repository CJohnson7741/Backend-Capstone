import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { fetchBookById, updateBook } from "../../managers/bookManager";
import { fetchGenres } from "../../managers/genreManager";
import "./EditBook.css";

export const EditBook = () => {
  const { bookId } = useParams();
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
    const loadBook = async () => {
      try {
        const bookData = await fetchBookById(bookId);
        setBook({
          title: bookData.title,
          description: bookData.description || "",
          condition: bookData.condition || "New",
          isbn: bookData.isbn || "",
          genreId: bookData.genreId || 1,
          authors: bookData.authors || [],
          imageUrl: bookData.imageUrl || "", // Load the imageUrl
        });
        setAuthorsList(bookData.authors || []);
      } catch (error) {
        console.error("Error fetching book details:", error);
      }
    };

    const loadGenres = async () => {
      try {
        const genreData = await fetchGenres();
        setGenres(genreData);
      } catch (error) {
        console.error("Error fetching genres:", error);
      }
    };

    loadBook();
    loadGenres();
  }, [bookId]);

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
        id: 0,
        name: authorInput.trim(),
      };

      setAuthorsList((prevAuthors) => [...prevAuthors, newAuthor]);
      setAuthorInput("");
    }
  };

  const handleRemoveAuthor = (author) => {
    setAuthorsList((prevAuthors) => prevAuthors.filter((a) => a !== author));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    const isConfirmed = window.confirm(
      "Are you sure you want to save these changes?"
    );

    if (isConfirmed) {
      try {
        const selectedGenre = genres.find((genre) => genre.id === book.genreId);
        const updatedBook = await updateBook(bookId, {
          ...book,
          genreName: selectedGenre ? selectedGenre.name : "",
          authors: authorsList,
        });

        if (updatedBook) {
          navigate(`/book/${bookId}`);
        } else {
          alert("Failed to update book");
        }
      } catch (error) {
        console.error("Error updating book:", error);
        alert("An error occurred while updating the book.");
      }
    }
  };

  return (
    <div className="edit-book-container mt-5">
      <h2>Edit Book</h2>
      <form onSubmit={handleSubmit}>
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
        <div>
          <label htmlFor="title">Title</label>
          <input
            type="text"
            id="title"
            name="title"
            value={book.title}
            onChange={handleInputChange}
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
          />
        </div>

        <div>
          <label htmlFor="description">Description</label>
          <textarea
            id="description"
            name="description"
            value={book.description}
            onChange={handleInputChange}
          />
        </div>

        <div>
          <label htmlFor="condition">Condition</label>
          <select
            id="condition"
            name="condition"
            value={book.condition}
            onChange={handleInputChange}
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
                    {author.name}{" "}
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

        <button type="submit">Save Changes</button>
      </form>
    </div>
  );
};

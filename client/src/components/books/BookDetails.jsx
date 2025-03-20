// BookDetails.js
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { fetchBookById, deleteBook } from "../../managers/bookManager";
import "./BookDetails.css";

export const BookDetails = () => {
  const [book, setBook] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    const loadBook = async () => {
      try {
        const bookData = await fetchBookById(id);
        setBook(bookData);
      } catch (error) {
        console.error("Error fetching book details:", error);
      }
    };

    loadBook();
  }, [id]);

  const handleDelete = async () => {
    const isConfirmed = window.confirm(
      "Are you sure you want to delete this book?"
    );

    if (isConfirmed) {
      try {
        await deleteBook(id);
        navigate("/library");
      } catch (error) {
        console.error("Error deleting the book:", error);
        alert("An error occurred while deleting the book.");
      }
    }
  };

  const handleEdit = () => {
    navigate(`/edit-book/${id}`);
  };

  if (!book) {
    return <p>Loading book details...</p>;
  }

  return (
    <div className="book-details-container">
      <img src={book.imageUrl} alt={book.title} />

      <h2>{book.title}</h2>
      <p>
        <strong>Genre:</strong> {book.genreName}
      </p>
      <p>
        <strong>Authors:</strong>{" "}
        {book.authors.map((author) => author.name).join(", ")}
      </p>
      <p>
        <strong>ISBN:</strong> {book.isbn}
      </p>
      <p>
        <strong>Description:</strong> {book.description}
      </p>
      <p>
        <strong>Condition:</strong> {book.condition}
      </p>
      {/* Book Condition displayed as read-only */}

      {/* Edit Button */}
      <button className="edit-button" onClick={handleEdit}>
        Edit Book
      </button>

      {/* Delete Button */}
      <button className="delete-button" onClick={handleDelete}>
        Delete Book
      </button>
    </div>
  );
};

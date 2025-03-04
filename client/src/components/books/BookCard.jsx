import React from "react";
import { useNavigate } from "react-router-dom";

export const BookCard = ({ book, onDelete }) => {
  const navigate = useNavigate();

  const handleDelete = () => {
    const isConfirmed = window.confirm(
      "Are you sure you want to delete this book?"
    );
    if (isConfirmed) {
      onDelete(book.id); // Call the onDelete function passed from the parent
    }
  };

  return (
    <div className="book-card">
      <h3 className="book-title">{book.title}</h3>
      <p>
        <strong>Genre:</strong> {book.genreName}
      </p>
      <p>
        <strong>Author(s):</strong>{" "}
        {book.authors.map((author) => author.name).join(", ")}
      </p>

      {/* Navigate to book details page */}
      <button
        className="details-button"
        onClick={() => navigate(`/book/${book.id}`)}
      >
        View Details
      </button>

      {/* Delete book button */}
      <button className="delete-button" onClick={handleDelete}>
        Delete
      </button>
    </div>
  );
};

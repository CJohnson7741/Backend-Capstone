const _apiUrl = "/api/books";

// Fetch books from the API
export const fetchBooks = async () => {
  try {
    const response = await fetch(_apiUrl, {
      method: "GET",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`Failed to fetch books. Status: ${response.status}`);
    }

    const books = await response.json(); // Parse the response as JSON
    return books; // This will be an array of BookDTO objects
  } catch (error) {
    console.error("Error fetching books:", error);
    throw error;
  }
};

// Delete a book by ID
export const deleteBook = async (bookId) => {
  try {
    const response = await fetch(`${_apiUrl}/${bookId}`, {
      method: "DELETE",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error("Failed to delete the book.");
    }

    return bookId; // Return the ID of the deleted book
  } catch (error) {
    console.error("Error deleting book:", error);
    throw error;
  }
};

// Fetch a specific book by its ID
export const fetchBookById = async (bookId) => {
  try {
    const response = await fetch(`${_apiUrl}/${bookId}`, {
      method: "GET",
      credentials: "same-origin", // Ensure cookies are sent with the request
    });

    if (!response.ok) {
      throw new Error(`Failed to fetch book. Status: ${response.status}`);
    }

    const book = await response.json(); // Parse the response as JSON
    return book; // This will be the BookDTO object
  } catch (error) {
    console.error("Error fetching book:", error);
    throw error;
  }
};

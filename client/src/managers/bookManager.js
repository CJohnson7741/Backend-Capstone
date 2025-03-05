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

export const updateBook = async (bookId, updatedBook) => {
  try {
    console.log("Updating book with data:", updatedBook); // Check the payload

    const response = await fetch(`${_apiUrl}/${bookId}`, {
      method: "PUT", // Ensure it's a PUT request
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedBook),
    });

    if (!response.ok) {
      throw new Error("Failed to update the book");
    }

    return await response.json(); // Return updated book data
  } catch (error) {
    console.error("Error updating book:", error);
    throw error;
  }
};

export const createBook = async (bookData) => {
  try {
    const response = await fetch("/api/books", {
      method: "POST",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(bookData),
    });

    if (response.ok) {
      return await response.json();
    } else {
      throw new Error("Failed to create book");
    }
  } catch (error) {
    console.error("Error creating book:", error);
    throw error;
  }
};

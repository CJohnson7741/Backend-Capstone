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
      method: "PUT",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedBook),
    });

    if (!response.ok) {
      const errorText = await response.text(); // Read the raw response text
      console.error("Error response:", errorText); // Log the raw error response
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
    debugger;
    const response = await fetch("/api/books", {
      method: "POST",
      credentials: "same-origin", // Ensure cookies are sent along with the request
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(bookData),
    });

    if (!response.ok) {
      // Log the response details to understand the error
      const errorData = await response.json(); // Try to parse the error response as JSON
      console.error("Error response:", errorData);

      // You can also log the status code for debugging
      console.error(`Failed to create book. Status: ${response.status}`);

      throw new Error(errorData.message || "Failed to create book");
    }

    return await response.json(); // Return the created book data if successful
  } catch (error) {
    debugger;
    // Log the error for debugging
    console.error("Error creating book:", error);

    // Rethrow the error for further handling in the UI
    throw error;
  }
};

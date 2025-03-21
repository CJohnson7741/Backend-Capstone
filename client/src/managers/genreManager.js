const _apiUrl = "/api/genre";

// Fetch all genres from the API
export const fetchGenres = async () => {
  try {
    const response = await fetch(`${_apiUrl}/genres`, {
      method: "GET",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
    });

    if (!response.ok) {
      throw new Error(`Failed to fetch genres. Status: ${response.status}`);
    }

    const genres = await response.json(); // Parse the response as JSON
    return genres; // This will be an array of GenreDTO objects
  } catch (error) {
    console.error("Error fetching genres:", error);
    throw error;
  }
};

// Add a new genre to the API
export const addGenre = async (newGenre) => {
  try {
    const response = await fetch(`${_apiUrl}/add`, {
      // Updated to match the new endpoint
      method: "POST",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newGenre),
    });

    if (!response.ok) {
      throw new Error("Failed to add genre.");
    }

    const createdGenre = await response.json(); // Parse the response as JSON
    return createdGenre; // Return the created genre
  } catch (error) {
    console.error("Error adding genre:", error);
    throw error;
  }
};

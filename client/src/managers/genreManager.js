const _apiUrl = "/api/genre";

// Fetch all genres from the API
export const fetchGenres = async () => {
  try {
    const response = await fetch(`${_apiUrl}/genres`, {
      method: "GET",
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

export const addGenre = async (newGenre) => {
  try {
    const response = await fetch(_apiUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newGenre),
    });

    if (!response.ok) {
      throw new Error("Failed to add genre.");
    }

    const createdGenre = await response.json(); //Parse the response as JSON
    return createdGenre; //Return the created genre
  } catch (error) {
    console.error("Error adding genre:", error);
    throw error;
  }
};

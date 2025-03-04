import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Library } from "./Library";
import { BookDetails } from "./books/BookDetails";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              Welcome to your Personal Library!
            </AuthorizedRoute>
          }
        />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />

        <Route
          path="library"
          element={<Library loggedInUser={loggedInUser} />}
        />

        {/* Add the route for book details */}
        <Route
          path="book/:id" // Dynamic route for book details
          element={<BookDetails />} // This will render the BookDetails component
        />
      </Route>

      {/* Catch-all route for 404 page */}
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}

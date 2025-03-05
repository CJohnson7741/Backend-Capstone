// ApplicationViews.js
import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Library } from "./Library";
import { BookDetails } from "./books/BookDetails";
import { EditBook } from "./books/EditBook"; // Import the new EditBook component

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              {" "}
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
        <Route
          path="book/:id" // Add the route for viewing book details
          element={<BookDetails />}
        />
        <Route
          path="edit-book/:bookId" // Add the route for editing the book
          element={<EditBook />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}

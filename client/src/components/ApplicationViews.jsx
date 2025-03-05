// ApplicationViews.js
import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Library } from "./Library";
import { BookDetails } from "./books/BookDetails";
import { EditBook } from "./books/EditBook"; // Import the new EditBook component
import { NewBook } from "./books/NewBook";

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
        <Route path="book/:id" element={<BookDetails />} />
        <Route path="edit-book/:bookId" element={<EditBook />} />
        <Route path="new-book" element={<NewBook />} />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}

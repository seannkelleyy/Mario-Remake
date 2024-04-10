import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import { LevelCreator } from "./Level-Creator.tsx";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <LevelCreator />
  </React.StrictMode>
);

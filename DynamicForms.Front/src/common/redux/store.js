import { configureStore } from "@reduxjs/toolkit";
import userForms from "./stores/userForms";

export const store = configureStore({
  reducer: {
    userForms: userForms,
  },
});

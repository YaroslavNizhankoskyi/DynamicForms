import { createSlice } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";

const initialState = [];

export const userForms = createSlice({
  name: "userForms",
  initialState,
  reducers: {
    addUserForms: (state, action) => {
      const form = state.find((el) => el.id == action.payload.id);

      if (!form) {
        state.push(action.payload);
      }
    },
    updateUserForm: (state, action) => {
      return state.map((el) => {
        if (el.id == action.payload.id) {
          return action.payload;
        }

        return el;
      });
    },
    resetUserForms: (state, action) => {
      return initialState;
    },
  },
});

export const { addUserForms, resetUserForms, updateUserForm } =
  userForms.actions;
export default userForms.reducer;

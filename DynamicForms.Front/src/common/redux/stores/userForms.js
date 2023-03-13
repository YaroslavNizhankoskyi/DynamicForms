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
    addOrUpdateForm: (state, action) => {
      var form = state.find((el) => el.id == action.payload.id);

      if (form) {
        return state.map((el) => {
          if (el.id == action.payload.id) {
            return action.payload;
          }

          return el;
        });
      } else {
        state.push(action.payload);
      }
    },
    removeUserForm: (state, action) => {
      state.splice(
        state.findIndex((form) => form.id === form.payload),
        1
      );
    },
    resetUserForms: (state, action) => {
      return initialState;
    },
  },
});

export const {
  addUserForms,
  resetUserForms,
  updateUserForm,
  removeUserForm,
  addOrUpdateForm,
} = userForms.actions;
export default userForms.reducer;

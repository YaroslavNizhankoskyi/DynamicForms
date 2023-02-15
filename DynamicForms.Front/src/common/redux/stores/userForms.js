import { createSlice } from "@reduxjs/toolkit";
import { useSelector } from "react-redux";

const initialState = {
  forms: [],
};

export const userForms = createSlice({
  name: "userForms",
  initialState,
  reducers: {
    addUserForms: (state, action) => {
      const form = state.forms.find((el) => el.id == action.payload.id);

      if (!form) {
        state.forms.push(action.payload);
      }
    },
    resetUserForms: (state, action) => {
      return initialState;
    },
  },
});

export const { addUserForms, resetUserForms } = userForms.actions;
export default userForms.reducer;

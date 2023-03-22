import axios from "axios";

export const setAuthToken = (token) => {
  if (token) {
    axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
  } else delete axios.defaults.headers.common["Authorization"];
};

export const deleteAuthToken = () => {
  delete axios.defaults.headers.common["Authorization"];
};

export const reinitializeAuthToken = () => {
  const token = localStorage.getItem("token");
  if (token) {
    setAuthToken(token);
  }
};

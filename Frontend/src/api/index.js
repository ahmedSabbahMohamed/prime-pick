import axios from "axios";

const getToken = () => {
  const token = localStorage.getItem("token");
  return token ? `Bearer ${token}` : null;
};

const getHeaders = () => {
  const token = getToken();
  if (token) {
    return {
      Authorization: token,
      "Content-Type": "multipart/form-data",
    };
  } else {
    return {
      "Content-Type": "multipart/form-data",
    };
  }
};

export const API = axios.create({
  baseURL: import.meta.env.VITE_BASE_API,
  headers: getHeaders(),
});

import axios from "axios";

const getToken = () => {
  const token = localStorage.getItem("token");
  return token ? `Bearer ${token}` : null;
};

const getHeaders = ({ hasAttachment = false }) => {
  const token = getToken();
  return hasAttachment
    ? { "Content-Type": "multipart/form-data", token }
    : { "Content-Type": "application/json", token };
};

export const API = axios.create({
  baseURL: import.meta.env.VITE_BASE_API,
  headers: getHeaders(),
});

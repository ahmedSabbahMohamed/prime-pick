import axios from "axios";
import { API } from "../../../api";
import { AUTH_ENDPOINTS } from "./authEndpoints";

export const register = (data) => {
  return API.post(AUTH_ENDPOINTS.REGISTER, data);
};

export const login = (data) => {
  return API.post(AUTH_ENDPOINTS.LOGIN, data);
};

export const phone = () => {
  axios.get(AUTH_ENDPOINTS.PHONE);
};

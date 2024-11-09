import { API } from "../../../api";
import { PARTNER_ENDPOINTS } from "./partnerEndpoints";

export const register = (data) => {
    return API.post(PARTNER_ENDPOINTS.REGISTER, data);
};

export const login = (data) => {
    return API.post(PARTNER_ENDPOINTS.LOGIN, data);
};

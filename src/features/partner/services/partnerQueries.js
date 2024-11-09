import * as SERVICES from "./partnerServices";
import { useAuthMutation } from "../../../hooks/useAuthMutation";

export const useRegister = () => {
  return useAuthMutation({
    serviceFn: SERVICES.register,
    onSuccessMsg: "created account successfully",
  });
};

export const useLogin = () => {
  return useAuthMutation({
    serviceFn: SERVICES.login,
    onSuccessMsg: "loggedin successfully",
  });
};

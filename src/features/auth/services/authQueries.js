import { useGlobalQuery } from "../../../hooks/useGlobalQuery";
import { useAuthMutation } from "../../../hooks/useAuthMutation";
import * as SERVICES from "./authServices";

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

export const usePhone = () => {
  return useGlobalQuery({
    queryKey: ["phone"],
    queryFn: SERVICES.phone,
  });
};

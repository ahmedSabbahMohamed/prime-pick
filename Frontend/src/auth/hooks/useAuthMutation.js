import { useMutation } from "@tanstack/react-query";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { handleLogin } from "../store/userSlice";
import successHandler from "../../request/successHandler";
import errorHandler from "../../request/errorHandler";

export const useAuthMutation = ({
  serviceFn,
  onSuccessMsg = "Logged in successfully",
  redirectPath = "/",
}) => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  return useMutation({
    mutationFn: serviceFn,
    onSuccess: (data) => {
      successHandler(onSuccessMsg);
      navigate(redirectPath);
      dispatch(handleLogin(data?.data?.data))
    },
    onError: (error) => {
      errorHandler(error?.response?.data?.status, error?.response?.data?.message);
    },
  });
};

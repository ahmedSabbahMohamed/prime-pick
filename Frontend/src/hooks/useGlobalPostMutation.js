import { useMutation } from "@tanstack/react-query";
import errorHandler from "../request/errorHandler";

export const useGlobalPostMutation = ({
  serviceFn,
  onSuccessCallback = null,
}) => {
  return useMutation({
    mutationFn: serviceFn,
    onSuccess: (data) => {
      console.log(data)
      if (onSuccessCallback) {
        onSuccessCallback(data);
      }
    },
    onError: (error) => {
      console.error(
        "An error occurred:",
        error?.response?.data || error.message
      );
      errorHandler(
        error?.response?.data?.status,
        error?.response?.data?.message
      );
    },
  });
};

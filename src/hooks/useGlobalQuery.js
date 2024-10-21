import { useQuery } from "@tanstack/react-query";

export const useGlobalQuery = ({ queryKey, queryFn, ...rest }) => {
  return useQuery({
    queryKey: queryKey,
    queryFn: queryFn,
    ...rest,
  });
};

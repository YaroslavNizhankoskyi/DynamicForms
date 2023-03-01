import { format } from "date-fns";

export const formatIsoDate = (stringDate) => {
  return format(new Date(stringDate), "dd MMM HH:mm:ss");
};

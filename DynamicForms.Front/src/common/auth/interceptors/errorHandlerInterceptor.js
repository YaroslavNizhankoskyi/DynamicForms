import axios from "axios";
import { NotificationManager } from "react-notifications";

function userAxiosGlobalErrorHandler() {
  axios.interceptors.response.use(undefined, function (error) {
    const statusCode = error.response ? error.response.status : null;
    switch (statusCode) {
      case 404:
        NotificationManager.error(
          "The requested resource does not exist or has been deleted"
        );
        break;
      case 500:
        NotificationManager.error("Internal server error");
        break;
      case 401:
        NotificationManager.error("Please login to access this resource");
        break;
      default:
        NotificationManager.error("Some error occured" + statusCode);
    }
  });
}

export default userAxiosGlobalErrorHandler;

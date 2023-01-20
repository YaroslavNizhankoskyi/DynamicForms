import Guards from "common/models/Guards";
import { NotificationManager } from "react-notifications";
import { Redirect } from "react-router-dom";

function isAuthorizedIn(role) {
  if (localStorage.getItem("token")) {
    let userData = JSON.parse(localStorage.getItem("userData"));
    return userData.role == role;
  }
  return false;
}

export function isAllowed(guard) {
  switch (guard) {
    case Guards.AUTHENTICATED:
      return localStorage.getItem("token");
    case Guards.ADMIN:
      return isAuthorizedIn(guard);
    case Guards.ANONYMOUS:
      return !localStorage.getItem("token");
    case Guards.NONE:
      return true;
    default:
      return false;
  }
}

export function getRedirect(guard) {
  switch (guard) {
    case Guards.AUTHENTICATED:
      return <Redirect to={{ pathname: "/auth/signin" }} />;
    case Guards.ADMIN:
      NotificationManager.error(
        `You are not in role ${guard} to access this page`
      );
      return <Redirect to={{ pathname: "/" }} />;
    case Guards.ANONYMOUS:
      NotificationManager.error(`Cannot authenticate again`);
      return <Redirect to={{ pathname: "/" }} />;
  }
}

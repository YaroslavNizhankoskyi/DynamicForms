import React from "react";
import { MdContactSupport } from "react-icons/md";
import { Route } from "react-router-dom";
import { isAllowed, getRedirect } from "./AccessRoute";
const AuthGuard = ({ guard, component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) => {
        if (isAllowed(guard)) {
          return <Component {...props} {...rest}></Component>;
        }

        return getRedirect(guard);
      }}
    ></Route>
  );
};

export default AuthGuard;

/*!

=========================================================
* Purity UI Dashboard - v1.0.1
=========================================================

* Product Page: https://www.creative-tim.com/product/purity-ui-dashboard
* Copyright 2021 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/purity-ui-dashboard/blob/master/LICENSE.md)

* Design by Creative Tim & Coded by Simmmple

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import React from "react";
import { createRoot } from "react-dom/client";
import theme from "theme/theme.js";
import { BrowserRouter, Switch } from "react-router-dom";
import { routes } from "routes";
import { getRoutesFor } from "./common/routing/routingHelper";
import { ChakraProvider } from "@chakra-ui/react";
import "react-notifications/lib/notifications.css";
import { NotificationContainer } from "react-notifications";
import { addCustomYupValidators } from "common/builder/validation/addCustomYupValidators";
import { store, persistor } from "common/redux/store";
import { Provider as ReduxProvider } from "react-redux";
import { PersistGate } from "redux-persist/integration/react";
import { reinitializeAuthToken } from "common/auth/headers/authHeader";
import useAxiosGlobalErrorHandler from "common/auth/interceptors/errorHandlerInterceptor";

const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

reinitializeAuthToken();
addCustomYupValidators();
useAxiosGlobalErrorHandler();

root.render(
  <ReduxProvider store={store}>
    <PersistGate loading={null} persistor={persistor}>
      <ChakraProvider theme={theme} resetCss={false}>
        <NotificationContainer />
        <BrowserRouter>
          <Switch>{getRoutesFor(routes, "index")}</Switch>
        </BrowserRouter>
      </ChakraProvider>
    </PersistGate>
  </ReduxProvider>
);

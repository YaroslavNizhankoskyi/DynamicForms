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
import ReactDOM from "react-dom";
import theme from "theme/theme.js";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import { routes } from "routes";
import { getRoutesFor } from "./common/routing/routingHelper";
import { ChakraProvider } from "@chakra-ui/react";
import "react-notifications/lib/notifications.css";
import { NotificationContainer } from "react-notifications";

ReactDOM.render(
  <ChakraProvider theme={theme} resetCss={false}>
    <NotificationContainer />
    <BrowserRouter>
      <Switch>{getRoutesFor(routes, "index")}</Switch>
    </BrowserRouter>
  </ChakraProvider>,
  document.getElementById("root")
);

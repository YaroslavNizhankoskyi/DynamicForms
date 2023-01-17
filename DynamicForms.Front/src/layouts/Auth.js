// chakra imports
import { Box, ChakraProvider, Portal } from "@chakra-ui/react";
import Footer from "components/Footer/Footer.js";
// core components
import AuthNavbar from "components/Navbars/AuthNavbar.js";
import React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import { routes } from "routes.js";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import {
  isActiveNavbar,
  getRoutesFor,
} from "./../common/routing/routingHelper";

export default function AuthPages(props) {
  const { ...rest } = props;
  // ref for the wrapper div
  const wrapper = React.createRef();
  React.useEffect(() => {
    document.body.style.overflow = "unset";
    // Specify how to clean up after this effect:
    return function cleanup() {};
  });

  const navRef = React.useRef();

  return (
    <Box ref={navRef} w="100%">
      <Portal containerRef={navRef}>
        <AuthNavbar
          secondary={isActiveNavbar(routes)}
          logoText="PURITY UI DASHBOARD"
        />
      </Portal>
      <Box w="100%">
        <Box ref={wrapper} w="100%">
          <Switch>
            {getRoutesFor(routes, "/auth")}
            <Redirect from="/auth" to="/auth/login-page" />
          </Switch>
        </Box>
      </Box>
      <Box px="24px" mx="auto" width="1044px" maxW="100%">
        <Footer />
      </Box>
    </Box>
  );
}

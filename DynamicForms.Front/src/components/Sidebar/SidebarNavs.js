import React from "react";
import { sidebar } from "./../../routes";
import { NavLink } from "react-router-dom";
import IconBox from "components/Icons/IconBox";
import { Button, Flex, Text, useColorModeValue } from "@chakra-ui/react";
import { isAllowed } from "common/auth/guards/AccessRoute";
import NavButton from "./NavButton";

function SidebarNavs() {
  const isActiveNav = (path) => {
    return window.location.pathname.endsWith(path.toLowerCase());
  };

  const getSidebar = (sidebar) => {
    return sidebar.map((nav) => {
      if (isAllowed(nav.guard)) {
        if (nav.category) {
          return (
            <div key={nav.category}>
              <Text
                color={useColorModeValue("gray.700", "white")}
                fontWeight="bold"
                mb={{
                  xl: "12px",
                }}
                mx="auto"
                ps={{
                  sm: "10px",
                  xl: "16px",
                }}
                py="12px"
              >
                {nav.category}
              </Text>
              {getSidebar(nav.children)}
            </div>
          );
        }

        if (nav.onClick) {
          return (
            <div key={nav.name}>
              <NavButton
                isActive={isActiveNav(nav.name)}
                onClick={nav.onClick}
                nav={nav}
              />
            </div>
          );
        }

        return (
          <NavLink to={nav.path} key={nav.name}>
            <NavButton isActive={isActiveNav(nav.name)} nav={nav} />
          </NavLink>
        );
      }

      return <></>;
    });
  };

  return <>{getSidebar(sidebar)}</>;
}

export default SidebarNavs;

import React from "react";
import { sidebar } from "./../../routes";
import { NavLink } from "react-router-dom";
import IconBox from "components/Icons/IconBox";
import { Button, Flex, Text, useColorModeValue } from "@chakra-ui/react";

function SidebarNavs() {
  const isActiveNav = (name) => {
    return window.location.pathname.endsWith(name.toLowerCase());
  };

  const activeBg = useColorModeValue("white", "gray.700");
  const inactiveBg = useColorModeValue("white", "gray.700");
  const activeColor = useColorModeValue("gray.700", "white");
  const inactiveColor = useColorModeValue("gray.400", "gray.400");

  const getSidebar = (sidebar) => {
    return sidebar.map((nav) => {
      if (nav.category) {
        return (
          <div key={nav.category}>
            <Text
              color={activeColor}
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
      return (
        <NavLink to={nav.path} key={nav.name}>
          {isActiveNav(nav.name) ? (
            <Button
              boxSize="initial"
              justifyContent="flex-start"
              alignItems="center"
              bg={activeBg}
              mb={{
                xl: "12px",
              }}
              mx={{
                xl: "auto",
              }}
              ps={{
                sm: "10px",
                xl: "16px",
              }}
              py="12px"
              borderRadius="15px"
              _hover="none"
              w="100%"
              _active={{
                bg: "inherit",
                transform: "none",
                borderColor: "transparent",
              }}
              _focus={{
                boxShadow: "none",
              }}
            >
              <Flex>
                {typeof nav.icon === "string" ? (
                  <Icon>{nav.icon}</Icon>
                ) : (
                  <IconBox
                    bg="teal.300"
                    color="white"
                    h="30px"
                    w="30px"
                    me="12px"
                  >
                    {nav.icon}
                  </IconBox>
                )}
                <Text color={activeColor} my="auto" fontSize="sm">
                  {nav.name}
                </Text>
              </Flex>
            </Button>
          ) : (
            <Button
              boxSize="initial"
              justifyContent="flex-start"
              alignItems="center"
              bg="transparent"
              mb={{
                xl: "12px",
              }}
              mx={{
                xl: "auto",
              }}
              py="12px"
              ps={{
                sm: "10px",
                xl: "16px",
              }}
              borderRadius="15px"
              _hover="none"
              w="100%"
              _active={{
                bg: "inherit",
                transform: "none",
                borderColor: "transparent",
              }}
              _focus={{
                boxShadow: "none",
              }}
            >
              <Flex>
                {typeof nav.icon === "string" ? (
                  <Icon>{nav.icon}</Icon>
                ) : (
                  <IconBox
                    bg={inactiveBg}
                    color="teal.300"
                    h="30px"
                    w="30px"
                    me="12px"
                  >
                    {nav.icon}
                  </IconBox>
                )}
                <Text color={inactiveColor} my="auto" fontSize="sm">
                  {nav.name}
                </Text>
              </Flex>
            </Button>
          )}
        </NavLink>
      );
    });
  };

  return <>{getSidebar(sidebar)}</>;
}

export default SidebarNavs;

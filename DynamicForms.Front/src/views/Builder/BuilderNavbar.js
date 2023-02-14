import { Box, HStack } from "@chakra-ui/react";
import NavImageLink from "components/Sidebar/NavImageLink";
import React from "react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { FaRegEye } from "react-icons/fa";

function BuilderNavbar() {
  return (
    <HStack
      col={8}
      spacing={10}
      justifyContent={"left"}
      alignItems={"center"}
      mx="auto"
      display="flex"
      w="100%"
      px="20px"
    >
      <NavImageLink
        logoText={"Home"}
        logo={CreativeTimLogo}
        link="/home"
      ></NavImageLink>
      <NavImageLink
        logoText={"Preview Form"}
        logo={FaRegEye}
        link="/home"
        iconSize="25px"
      ></NavImageLink>
    </HStack>
  );
}

export default BuilderNavbar;

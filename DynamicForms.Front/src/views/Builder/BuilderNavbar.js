import { Stack, SimpleGrid, Box } from "@chakra-ui/react";
import HomeLink from "components/Sidebar/HomeLink";
import NavButton from "components/Sidebar/NavButton";
import React from "react";
import { sidebar } from "routes";

function BuilderNavbar() {
  return (
    <SimpleGrid
      row={8}
      spacing={10}
      justifyContent={"left"}
      alignItems={"center"}
      mx="auto"
      display="flex"
      w="100%"
      px="20px"
    >
      <HomeLink logoText={"Home"}></HomeLink>
    </SimpleGrid>
  );
}

export default BuilderNavbar;

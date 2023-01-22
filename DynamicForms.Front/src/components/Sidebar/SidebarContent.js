/*eslint-disable*/
// chakra imports
import { Box, Link, Stack, Text } from "@chakra-ui/react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { Separator } from "components/Separator/Separator";
import { SidebarHelp } from "components/Sidebar/SidebarHelp";
import React from "react";
import SidebarNavs from "./SidebarNavs";

const SidebarContent = ({ logoText }) => {
  console.log(process.env.PUBLIC_URL);
  return (
    <>
      <Box pt={"25px"} mb="12px">
        <Link
          href="/home"
          display="flex"
          lineHeight="100%"
          mb="30px"
          fontWeight="bold"
          justifyContent="left"
          alignItems="center"
          fontSize="11px"
        >
          <CreativeTimLogo w="32px" h="32px" me="10px" />
          <Text fontSize="sm" mt="3px">
            {logoText}
          </Text>
        </Link>
        <Separator></Separator>
      </Box>
      <Stack direction="column" mb="40px">
        <Box>
          <SidebarNavs></SidebarNavs>
        </Box>
      </Stack>
      <SidebarHelp />
    </>
  );
};

export default SidebarContent;

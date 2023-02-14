/*eslint-disable*/
// chakra imports
import { Box, Stack } from "@chakra-ui/react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { Separator } from "components/Separator/Separator";
import { SidebarHelp } from "components/Sidebar/SidebarHelp";
import React from "react";
import SidebarNavs from "./SidebarNavs";
import NavImageLink from "./NavImageLink";

const SidebarContent = ({ logoText }) => {
  console.log(process.env.PUBLIC_URL);
  return (
    <>
      <Box pt={"25px"} mb="12px">
        <NavImageLink
          logoText={logoText}
          logo={CreativeTimLogo}
          link="/home"
        ></NavImageLink>
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

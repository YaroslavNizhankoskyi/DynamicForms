import React, { createElement } from "react";
import { Link, Text, Icon } from "@chakra-ui/react";
import { NavLink } from "react-router-dom";

function NavImageLink({ logoText, logo, link, iconSize }) {
  iconSize ??= "32px";

  return (
    <Link
      as={NavLink}
      to={link}
      display="flex"
      lineHeight="100%"
      fontWeight="bold"
      justifyContent="left"
      alignItems="center"
      fontSize="11px"
      h="32px"
    >
      <Icon h={iconSize} w={iconSize} me="8px" as={logo}></Icon>

      <Text fontSize="sm" mt="3px" display={"flex"}>
        {logoText}
      </Text>
    </Link>
  );
}

export default NavImageLink;

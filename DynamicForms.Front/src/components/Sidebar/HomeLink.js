import React from "react";
import { Link, Text } from "@chakra-ui/react";
import { CreativeTimLogo } from "components/Icons/Icons";
import { NavLink } from "react-router-dom";

function HomeLink({ logoText }) {
  return (
    <Link
      as={NavLink}
      to="/home"
      display="flex"
      lineHeight="100%"
      fontWeight="bold"
      justifyContent="left"
      alignItems="center"
      fontSize="11px"
    >
      <CreativeTimLogo display={"flex"} w="32px" h="32px" me="10px" />
      <Text fontSize="sm" mt="3px" display={"flex"}>
        {logoText}
      </Text>
    </Link>
  );
}

export default HomeLink;

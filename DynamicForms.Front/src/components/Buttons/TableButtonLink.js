import React from "react";
import { Button, Link, Text } from "@chakra-ui/react";
import { NavLink } from "react-router-dom";

function TableButtonLink({ color, link, text, icon }) {
  return (
    <Link as={NavLink} to={link}>
      <Button size={"md"} rightIcon={icon} colorScheme={color} variant="solid">
        <Text
          fontSize="md"
          colorScheme={color}
          fontWeight="bold"
          cursor="pointer"
        >
          {text}
        </Text>
      </Button>
    </Link>
  );
}

export default TableButtonLink;

import React from "react";
import IconBox from "components/Icons/IconBox";
import { Button, Flex, Text, useColorModeValue } from "@chakra-ui/react";

function NavButton({ isActive, onClick, nav }) {
  let bg = useColorModeValue(isActive ? "gray.100" : "white", "gray.700");
  let color = useColorModeValue(
    isActive ? "gray.700" : "gray.400",
    isActive ? "white" : "gray.400"
  );

  return (
    <Button
      onClick={onClick}
      boxSize="initial"
      justifyContent="flex-start"
      alignItems="center"
      bg={bg}
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
          <IconBox bg="teal.300" color="white" h="30px" w="30px" me="12px">
            {nav.icon}
          </IconBox>
        )}
        <Text color={color} my="auto" fontSize="sm">
          {nav.name}
        </Text>
      </Flex>
    </Button>
  );
}

export default NavButton;

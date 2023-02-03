import React, { useState } from "react";
import {
  Text,
  FormControl as ChakraControl,
  FormLabel,
  HStack,
  VStack,
  IconButton,
} from "@chakra-ui/react";
import { MdSettingsApplications, MdOutlineDeleteForever } from "react-icons/md";

function FormControl({ control, onDelete, openSetup }) {
  const Component = control.component;
  let isValid = true;

  const [isFocused, setIsFocused] = useState(false);

  const handleOnBlur = (event) => {
    setTimeout(() => setIsFocused(false), 200);
  };

  return (
    <HStack p="10px" onFocus={() => setIsFocused(true)} onBlur={handleOnBlur}>
      <ChakraControl variant={"control"}>
        <FormLabel>{control.name}</FormLabel>
        <Component variant={control.defaultVariant}></Component>
        {isValid ? <></> : <Text as="u">{error}</Text>}
      </ChakraControl>
      <VStack display={isFocused ? "inherit" : "none"}>
        <IconButton
          bg="blue.400"
          aria-label="Settigns"
          icon={<MdSettingsApplications size={"32px"} />}
          size={"sm"}
          rounded="6px"
          onClick={openSetup}
        />
        <IconButton
          bg={"red.400"}
          aria-label="Delete"
          icon={<MdOutlineDeleteForever size={"32px"} />}
          size={"sm"}
          rounded={"6px"}
          onClick={(e) => onDelete(e, control.id)}
        />
      </VStack>
    </HStack>
  );
}

export default FormControl;

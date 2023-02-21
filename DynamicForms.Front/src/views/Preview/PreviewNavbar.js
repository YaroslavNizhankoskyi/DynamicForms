import React from "react";
import { Grid, Box, Flex, Icon } from "@chakra-ui/react";
import GenericNavbar from "components/Navbars/GenericNavbar";
import NavImageLink from "components/Sidebar/NavImageLink";
import {
  FaArrowLeft,
  FaDesktop,
  FaMobileAlt,
  FaTabletAlt,
} from "react-icons/fa";

function PreviewNavbar({ formId, display, setDisplay }) {
  const selectedColor = "#41c7bf";
  const defaultColor = "black";
  const getColor = (type) => (display == type ? selectedColor : defaultColor);

  return (
    <GenericNavbar height="100px">
      <Grid templateColumns="repeat(3, 1fr)" gap={6} w={"100%"}>
        <Box>
          <NavImageLink
            logoText={"Builder"}
            logo={FaArrowLeft}
            link={`/${formId}/builder`}
            iconSize="20px"
          ></NavImageLink>
        </Box>
        <Flex gap={2} justifyContent={"space-around"}>
          <Icon
            as={FaDesktop}
            boxSize={"40px"}
            color={getColor("Desktop")}
            onClick={() => setDisplay("Desktop")}
          />
          <Icon
            as={FaTabletAlt}
            boxSize={"40px"}
            color={getColor("Tablet")}
            onClick={() => setDisplay("Tablet")}
          />
          <Icon
            as={FaMobileAlt}
            boxSize={"40px"}
            color={getColor("Mobile")}
            onClick={() => setDisplay("Mobile")}
          />
        </Flex>
        <Box />
      </Grid>
    </GenericNavbar>
  );
}

export default PreviewNavbar;

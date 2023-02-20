import GenericNavbar from "components/Navbars/GenericNavbar";
import NavImageLink from "components/Sidebar/NavImageLink";
import React, { useState } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import { FaRegEye } from "react-icons/fa";
import { Box, Grid, GridItem, Heading, Text, VStack } from "@chakra-ui/react";
import FormViewVariant from "./FormViewVariant";
import PreviewNavbar from "./PreviewNavbar";

function Preview() {
  const [displayType, setDisplayType] = useState("Desktop");

  const { formId } = useParams();
  const form = useSelector((state) =>
    state.userForms.forms.find((el) => el.id == formId)
  );

  const renderDisplayView = () => {
    let width = "90%";
    switch (displayType) {
      case "Mobile":
        width = "30%";
        break;
      case "Tablet":
        width = "50%";
        break;
      default:
        width = "90%";
    }
    return <FormViewVariant width={width}></FormViewVariant>;
  };

  const renderForm = () => {};

  return (
    <Box>
      {" "}
      <PreviewNavbar
        formId={formId}
        display={displayType}
        setDisplay={setDisplayType}
      />
      <Box minH={""}>
        <VStack
          px={"100px"}
          pb="80px"
          pt="20px"
          h={"95vh"}
          display={"flex"}
          justifyContent={"center"}
          alignItems={"center"}
          backgroundColor={"gray.300"}
          minH={"600px"}
        >
          <Heading mb={"5"}>{displayType} view</Heading>
          {renderDisplayView()}
        </VStack>
      </Box>
    </Box>
  );
}

export default Preview;

import React, { useState, createElement } from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import { Box, Heading, VStack } from "@chakra-ui/react";
import FormViewVariant from "./FormViewVariant";
import PreviewNavbar from "./PreviewNavbar";
import ControlPreviewList from "./ControlPreviewList";

function Preview() {
  const [displayType, setDisplayType] = useState("Desktop");
  const { formId } = useParams();

  let form = useSelector((state) =>
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
    return (
      <FormViewVariant width={width}>
        {form ? <ControlPreviewList controls={form.controls} /> : <></>}
      </FormViewVariant>
    );
  };

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

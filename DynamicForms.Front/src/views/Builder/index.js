import React, { useState } from "react";
import { Grid, GridItem, Box } from "@chakra-ui/react";
import Controls from "./Controls";
import FormBuilder from "./FormBuilder";
import BuilderNavbar from "./BuilderNavbar";
import { DragDropContext } from "@hello-pangea/dnd";
import controlsData from "variables/controls";
import { setupDefaultValidation } from "common/builder/validation/yupSchemaCreator";

function DynamicFormsBuilder() {
  let [controls, setControls] = useState([]);

  const handleOnDragEnd = (result) => {
    let items = [...controls];
    let controlData = controlsData.find((el) => el.type == result.draggableId);

    let control = {
      id: Date.now(),
      ...controlData,
      inputConfig: {
        ...controlData.inputConfig,
      },
      validation: {
        ...controlData.validation,
      },
    };

    setupDefaultValidation(control);
    items.push(control);
    setControls(items);
  };

  return (
    <DragDropContext onDragEnd={handleOnDragEnd}>
      <BuilderNavbar controls={controls} />
      <Grid
        bg={"blackAlpha.200"}
        p={"10px"}
        templateRows={"repeat(8, 1fr)"}
        templateColumns={"repeat(6, 1fr)"}
        gap={4}
        minH={"100vh"}
      >
        <GridItem rowSpan={7} colSpan={1} bg={"whiteAlpha.800"} rounded={"md"}>
          <Controls />
        </GridItem>
        <GridItem rowSpan={7} colSpan={5} bg={"gray.500"} rounded={"md"}>
          <FormBuilder controls={controls} setControls={setControls} />
        </GridItem>
      </Grid>
    </DragDropContext>
  );
}

export default DynamicFormsBuilder;

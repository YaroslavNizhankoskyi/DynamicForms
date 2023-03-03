import React, { useState, useEffect } from "react";
import { Grid, GridItem, Box } from "@chakra-ui/react";
import Controls from "./Controls";
import FormBuilder from "./FormBuilder";
import { DragDropContext } from "@hello-pangea/dnd";
import controlsData from "variables/controls";
import { setupDefaultValidation } from "common/builder/validation/yupSchemaCreator";

function DynamicFormsBuilder({ form, setForm }) {
  const handleOnDragEnd = (result) => {
    const { source, destination } = result;

    if (!destination) {
      return;
    }

    switch (source.droppableId) {
      case destination.droppableId:
        reorder(result);
        break;
      case "controls":
        add(result);
        break;
      default:
        return;
    }
  };

  const reorder = (moveResult) => {
    const [reorderedItem] = form.controls.splice(moveResult.source.index, 1);
    form.controls.splice(moveResult.destination.index, 0, reorderedItem);

    setFormControls(form.controls);
  };

  const add = (addResult) => {
    let controlData = controlsData.find(
      (el) => el.type == addResult.draggableId
    );

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
    form.controls.splice(addResult.destination.index, 0, control);
    setFormControls(form.controls);
  };

  const setFormControls = (controls) => {
    const formCopy = { ...form, controls: [...controls] };
    setForm(formCopy);
  };

  return (
    <DragDropContext onDragEnd={handleOnDragEnd}>
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
          <FormBuilder controls={form.controls} setControls={setFormControls} />
        </GridItem>
      </Grid>
    </DragDropContext>
  );
}

export default DynamicFormsBuilder;

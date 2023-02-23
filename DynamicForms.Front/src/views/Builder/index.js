import React, { useState, useEffect } from "react";
import { Grid, GridItem, Box } from "@chakra-ui/react";
import Controls from "./Controls";
import FormBuilder from "./FormBuilder";
import BuilderNavbar from "./BuilderNavbar";
import { DragDropContext } from "@hello-pangea/dnd";
import controlsData from "variables/controls";
import { setupDefaultValidation } from "common/builder/validation/yupSchemaCreator";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";

function DynamicFormsBuilder() {
  const { formId } = useParams();
  let [form, setForm] = useState({ id: formId, controls: [] });

  let existingForm = useSelector((state) => {
    console.log(state.userForms);
    return state.userForms.find((el) => el.id == formId);
  });

  useEffect(() => {
    if (existingForm) {
      existingForm = structuredClone(existingForm);

      const createdControls = existingForm.controls.map((el) => {
        const controlData = controlsData.find((c) => c.type == el.type);

        if (controlData) {
          el.component = controlData.component;
          el.icon = controlData.icon;
        }

        return el;
      });

      existingForm.controls = createdControls;

      setForm(existingForm);
    }
  }, []);

  const handleOnDragEnd = (result) => {
    const formCopy = { ...form, controls: [...form.controls] };
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
    formCopy.controls.push(control);
    setForm(formCopy);
  };

  const setFormControls = (controls) => {
    const formCopy = { ...form, controls: [...controls] };
    setForm(formCopy);
  };

  return (
    <DragDropContext onDragEnd={handleOnDragEnd}>
      <BuilderNavbar form={form} />
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

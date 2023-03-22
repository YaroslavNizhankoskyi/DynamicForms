import controlsData from "variables/controls";
import { getControlValidationValue } from "./getControlValues";

export const refillFormData = (form) => {
  let clonedForm = structuredClone({ ...form });

  const createdControls = clonedForm.controls.map((el) => {
    const controlData = controlsData.find((c) => c.type == el.type);

    if (controlData) {
      el.component = controlData.component;
      el.icon = controlData.icon;
    }

    return el;
  });

  clonedForm.controls = createdControls;
  return clonedForm;
};

export const getSaveableForm = (form) => {
  const formCopy = { ...form };

  const serializableControls = form.controls.map((el) => {
    return { ...el, icon: undefined, component: undefined };
  });

  formCopy.controls = serializableControls;

  return structuredClone(formCopy);
};

export const getApiSavableForm = (form) => {
  const inputs = [];
  const selects = [];

  for (var i = 0; i < form.controls.length; i++) {
    let element = form.controls[i];
    if (element.type.includes("_input")) {
      let config = JSON.stringify({
        inputConfig: element.config,
        validation: element.validation,
      });

      let isRequired = getControlValidationValue("isRequired", element)[0];

      var stringEnum = element.type.replace("_input", "");

      let control = {
        position: i,
        type: stringEnum.charAt(0).toUpperCase() + stringEnum.slice(1),
        isRequired,
        config,
      };

      inputs.push(control);
    }
  }

  return {
    inputs,
    visibility: form.visibility,
    description: form.description,
    id: form.id,
    name: form.name,
    domain: form.domain,
    dateCreated: form.dateCreated,
    dateModified: form.dateModified,
    selects: selects,
  };
};

import controlsData from "variables/controls";

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

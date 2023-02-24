export const getControlsInitialValues = (controls) => {
  return controls.reduce((init, el) => {
    const id = el.id;
    return { ...init, [id]: "" };
  }, {});
};

export const getControlsValues = (controlIds) => {
  return controlIds.reduce((init, id) => {
    return { ...init, [id]: "" };
  }, {});
};

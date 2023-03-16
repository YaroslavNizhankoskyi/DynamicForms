export const getFormikValues = (source, properties) => {
  return properties.reduce((init, property) => {
    init[property] = source[property];
    return init;
  }, {});
};

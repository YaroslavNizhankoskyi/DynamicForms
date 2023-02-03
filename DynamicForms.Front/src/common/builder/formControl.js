import controls from "variables/controls";

function getFormControl(controlType, props) {
  const Component = controls.find((el) => el.type == controlType).component;

  return <Component {...props}></Component>;
}

export default getFormControl;

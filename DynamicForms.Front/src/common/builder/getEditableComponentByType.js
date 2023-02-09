import { Input, Switch } from "@chakra-ui/react";
import NumberEditable from "views/Builder/drawer/editables/NumberEditable";

const getEditableComponentByType = (type) => {
  switch (type) {
    case "string":
      return Input;
    case "boolean":
      return Switch;
    case "number":
      return NumberEditable;
    default:
      return <p>NotFound</p>;
  }
};

export default getEditableComponentByType;

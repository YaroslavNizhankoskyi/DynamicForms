import { MdOutlineEmail, MdTextFields } from "react-icons/md";
import { TbNumbers } from "react-icons/tb";
import EmailInput from "views/Builder/controls/EmailInput";
import NumberInput from "views/Builder/controls/NumberInput";
import TextInput from "views/Builder/controls/TextInput";

const controls = [
  {
    name: "Text",
    type: "text_input",
    icon: MdTextFields,
    component: TextInput,
    inputConfig: {
      placeholder: "test",
      variant: "control",
    },
    validation: {
      validationType: "string",
      usedValidators: ["string_max", "string_min", "isRequired"],
    },
  },
  {
    name: "Number",
    type: "number_input",
    icon: TbNumbers,
    component: NumberInput,
    inputConfig: {
      placeholder: "test",
      variant: "control",
    },
    validation: {
      validationType: "number",
      usedValidators: ["number_max", "number_min", "isRequired"],
    },
  },
  {
    name: "Email",
    type: "email_input",
    icon: MdOutlineEmail,
    component: EmailInput,
    inputConfig: {
      placeholder: "test",
      variant: "control",
    },
    validation: {
      validationType: "string",
      usedValidators: ["email_max", "email_min", "isRequired"],
    },
  },
];

export default controls;

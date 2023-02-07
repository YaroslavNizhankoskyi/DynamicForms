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
    defaultVariant: "control",
    validation: {
      validationType: "string",
      usedValidators: ["string_max", "string_min", "required"],
    },
  },
  {
    name: "Number",
    type: "number_input",
    icon: TbNumbers,
    component: NumberInput,
    defaultVariant: "control",
    validation: {
      validationType: "number",
      usedValidators: ["number_max", "number_min", "required"],
    },
  },
  {
    name: "Email",
    type: "email_input",
    icon: MdOutlineEmail,
    component: EmailInput,
    defaultVariant: "control",
    validation: {
      validationType: "string",
      usedValidators: ["email_max", "email_min", "required"],
    },
  },
];

export default controls;

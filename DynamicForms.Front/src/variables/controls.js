import { MdOutlineEmail, MdTextFields } from "react-icons/md";
import { TbNumbers } from "react-icons/tb";
import EmailInput from "views/Builder/controls/EmailInput";
import NumberInput from "views/Builder/controls/NumberInput";
import TextInput from "views/Builder/controls/TextInput";

const controls = [
  {
    name: "Text",
    id: "text_input",
    icon: MdTextFields,
    component: TextInput,
    defaultVariant: "control",
  },
  {
    name: "Number",
    id: "number_input",
    icon: TbNumbers,
    component: NumberInput,
    defaultVariant: "control",
  },
  {
    name: "Email",
    id: "email_input",
    icon: MdOutlineEmail,
    component: EmailInput,
    defaultVariant: "control",
  },
];

export default controls;

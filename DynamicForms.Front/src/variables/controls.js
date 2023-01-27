import { MdOutlineEmail, MdTextFields } from "react-icons/md";
import { TbNumbers } from "react-icons/tb";

const controls = [
  {
    name: "Text",
    type: "text_input",
    icon: MdTextFields,
  },
  {
    name: "Number",
    type: "number_input",
    icon: TbNumbers,
  },
  {
    name: "Email",
    type: "email_input",
    icon: MdOutlineEmail,
  },
];

export default controls;

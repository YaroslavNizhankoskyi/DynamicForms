import { MdOutlineEmail, MdTextFields } from "react-icons/md";
import { TbNumbers } from "react-icons/tb";

const controls = [
  {
    name: "Text",
    id: "text_input",
    icon: MdTextFields,
  },
  {
    name: "Number",
    id: "number_input",
    icon: TbNumbers,
  },
  {
    name: "Email",
    id: "email_input",
    icon: MdOutlineEmail,
  },
];

export default controls;

import userForms from "common/redux/stores/userForms";
import React from "react";
import { useSelector } from "react-redux";
import { useParams } from "react-router-dom";

function Preview() {
  const { formId } = useParams();
  const form = useSelector((state) =>
    state.userForms.forms.find((el) => el.id == formId)
  );

  console.log(form);

  return <p>{form.id}</p>;
}

export default Preview;

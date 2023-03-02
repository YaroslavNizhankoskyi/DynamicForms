import { getRoutesFor } from "common/routing/routingHelper";
import React, { useState } from "react";
import { Switch, Redirect } from "react-router-dom";
import { routes } from "routes.js";
import { useParams } from "react-router-dom";
import BuilderNavbar from "views/Builder/BuilderNavbar";

function Form() {
  const { formId } = useParams();

  const initialForm = {
    id: formId,
    controls: [],
    name: "unset",
    domain: "unset",
    created: new Date(),
    modified: new Date(),
    status: "unsaved",
  };
  let t = getRoutesFor(routes, `/form`);

  const [form, setForm] = useState(initialForm);

  return (
    <>
      <BuilderNavbar form={form} setForm={setForm} />
      <Switch>
        {getRoutesFor(routes, `/form`, { form, setForm })}
        <Redirect from="/admin" to="/home" />
      </Switch>
    </>
  );
}

export default Form;

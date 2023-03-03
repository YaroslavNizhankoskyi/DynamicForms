import { getRoutesFor } from "common/routing/routingHelper";
import React, { useState, useEffect } from "react";
import { Switch, Redirect } from "react-router-dom";
import { routes } from "routes.js";
import { useParams } from "react-router-dom";
import BuilderNavbar from "views/Builder/BuilderNavbar";
import { useSelector } from "react-redux";

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

  let existingForm = useSelector((state) =>
    state.userForms.find((el) => el.id == form.id)
  );

  if (existingForm) {
    refillFormData();
  }

  const refillFormData = () => {
    existingForm = structuredClone(existingForm);

    const createdControls = existingForm.controls.map((el) => {
      const controlData = controlsData.find((c) => c.type == el.type);

      if (controlData) {
        el.component = controlData.component;
        el.icon = controlData.icon;
      }

      return el;
    });

    existingForm.controls = createdControls;

    setForm(existingForm);
  };

  return (
    <>
      <BuilderNavbar
        form={form}
        setForm={setForm}
        formExists={existingForm && true}
      />
      <Switch>
        {getRoutesFor(routes, `/form`, { form, setForm })}
        <Redirect from="/admin" to="/home" />
      </Switch>
    </>
  );
}

export default Form;
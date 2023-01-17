import { Route } from "react-router-dom";

export function getActiveRoute(routes) {
  return "admin";
}

export function isActiveNavbar(routes) {
  return false;
}

export function getRoutesFor(routes, pathes) {
  if (pathes == "index") {
    return routes.map((el) => {
      return <Route path={el.path} component={el.component} key={el.name} />;
    });
  }

  let route = routes.find((el) => el.path == pathes);

  if (!route) {
    let parentRoute = routes.find((el) => pathes.startsWith(el.path));

    if (!parentRoute.children) return null;

    return getRoutesFor(parentRoute.children, pathes);
  }

  return route.children.map((el) => {
    return <Route path={el.path} component={el.component} key={el.name} />;
  });

  return null;
}

import AuthGuard from "common/auth/guards/AuthGuard";
import { matchPath } from "react-router-dom/cjs/react-router-dom.min";

export function getActiveRoute() {
  return "admin";
}

export function isActiveNavbar() {
  return false;
}

export function getRoutesFor(routes, pathes, rest) {
  if (pathes == "index") {
    return routes.map((el) => {
      return (
        <AuthGuard
          guard={el.guard}
          path={el.path}
          component={el.component}
          key={el.name}
          {...rest}
        />
      );
    });
  }

  let route = routes.find((el) => matchPath(pathes, el.path));

  if (!route) {
    let parentRoute = routes.find((el) => pathes.startsWith(el.path));

    if (!parentRoute.children) return null;

    return getRoutesFor(parentRoute.children, pathes);
  }

  return route.children.map((el) => {
    return (
      <AuthGuard
        guard={el.guard}
        path={el.path}
        component={el.component}
        key={el.name}
        {...rest}
      />
    );
  });

  return null;
}

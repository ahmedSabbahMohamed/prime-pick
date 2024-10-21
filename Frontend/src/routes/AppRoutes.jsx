import { Route, Routes } from "react-router-dom";
import RoutesConfig from "./RoutesConfig";

function AppRoutes() {
  const routes = RoutesConfig();

  return (
    <Routes>
      {routes.map((route, index) => {
        return (
          <Route key={index} path={route?.path} element={route?.element} />
        );
      })}
    </Routes>
  );
}

export default AppRoutes;

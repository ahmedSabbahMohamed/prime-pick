import Register from "../pages/Register";
import Signin from "../pages/Signin";

function RoutesConfig() {
  const routes = [
    { path: "/register", element: <Register />, isAuth: false },
    { path: "/sign-in", element: <Signin />, isAuth: false },
  ];
  return routes;
}

export default RoutesConfig;

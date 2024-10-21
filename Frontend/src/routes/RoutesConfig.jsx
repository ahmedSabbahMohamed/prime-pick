import Register from "../pages/Register";
import Signin from "../pages/Signin";
import Stays from "../pages/Stays";

function RoutesConfig() {
  const routes = [
    { path: "/register", element: <Register />, isAuth: false },
    { path: "/sign-in", element: <Signin />, isAuth: false },
    { path: "/", element: <Stays />, isAuth: false },
  ];
  return routes;
}

export default RoutesConfig;

import Partner from "../pages/Partner";
import Register from "../pages/Register";
import RegisterPartner from "../pages/RegisterPartner";
import Signin from "../pages/Signin";
import Stays from "../pages/Stays";
import SigninPartner from "../pages/SigninPartner";

function RoutesConfig() {
  const routes = [
    { path: "/register", element: <Register />, isAuth: false },
    { path: "/sign-in", element: <Signin />, isAuth: false },
    { path: "/", element: <Stays />, isAuth: false },
    { path: "/partner", element: <Partner />, isAuth: false },
    { path: "/partner-register", element: <RegisterPartner />, isAuth: false },
    { path: "/partner-sign-in", element: <SigninPartner />, isAuth: false },
  ];
  return routes;
}

export default RoutesConfig;

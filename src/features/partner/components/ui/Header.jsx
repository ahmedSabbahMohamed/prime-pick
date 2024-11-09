import { Button } from "antd";
import Logo from "../../../../components/ui/Logo"
import { Link } from "react-router-dom";

function Header() {
  return (
    <div className="flex justify-between items-center h-[60px]">
      <Logo />
      <div className="flex overflow-auto gap-2 items-center">
        <p className="text-xs text-gray-200 text-nowrap hidden sm:block">
          Already a partner?
        </p>
        <Button ghost>
          <Link to={"/partner-sign-in"}>Sign in</Link>
        </Button>
        <Button type="primary">
          <Link to={"/help"}>Help</Link>
        </Button>
      </div>
    </div>
  );
}

export default Header
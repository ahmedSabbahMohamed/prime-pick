import { UserOutlined } from "@ant-design/icons";
import { Button, Tooltip } from "antd";
import React from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import Logout from "./Logout";

function AuthButtons() {
  const { user, isLogin } = useSelector((state) => state.user);

  return isLogin ? (
    <div className="flex gap-2">
      <Tooltip title={user?.name}>
        <Button ghost color="default" shape="circle" icon={<UserOutlined />} />
      </Tooltip>
      <Logout />
    </div>
  ) : (
    <>
      <div className="lg:flex gap-4 flex-row hidden">
        <Button ghost className="bg-white">
          <Link to={"/register"}>Register</Link>
        </Button>
        <Button ghost>
          <Link to={"/sign-in"}>Sign In</Link>
        </Button>
      </div>
      <Tooltip title={"Sign in"} className="lg:hidden">
        <Link to={"sign-in"}>
          <Button
            ghost
            color="default"
            shape="circle"
            icon={<UserOutlined />}
          />
        </Link>
      </Tooltip>
    </>
  );
}

export default AuthButtons;

import { UserOutlined } from "@ant-design/icons";
import { Button } from "antd";
import React from "react";
import { Link } from "react-router-dom";

function AuthButtons() {
  return (
    <>
      <div className="lg:flex gap-4 flex-row hidden">
        <Button ghost className="bg-white">
          <Link to={"/register"}>Register</Link>
        </Button>
        <Button ghost>
          <Link to={"/sign-in"}>Sign In</Link>
        </Button>
      </div>
      <Link to={"sign-in"} className="text-2xl lg:hidden">
        <UserOutlined className="text-white" />
      </Link>
    </>
  );
}

export default AuthButtons;

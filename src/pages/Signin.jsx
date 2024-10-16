import React from "react";
import Loading from "../components/ui/Loading";
import { Button, Form } from "antd";
import SigninForm from "../auth/components/form/SigninForm";
import AuthModule from "../auth/components/ui/AuthModule";

function Signin() {
  const FormContainer = () => (
    <Loading isLoading={false}>
      <Form layout="vertical" name="normal_login" className="login-form">
        <SigninForm />
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={false}
            size="large"
          >
            {"Sign in"}
          </Button>
        </Form.Item>
      </Form>
    </Loading>
  );

  return (
    <AuthModule AUTH_TITLE={"Sign in"}>
      <FormContainer />
    </AuthModule>
  );
}

export default Signin;

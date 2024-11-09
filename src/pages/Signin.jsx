import React from "react";
import Loading from "../components/ui/Loading";
import { Button, Form } from "antd";
import SigninForm from "../features/auth/components/form/SigninForm";
import AuthModule from "../features/auth/components/ui/AuthModule";
import { useLogin } from "../features/auth/services";
import convertToFormData from "../utils/convertToFormData";

function Signin() {
  const { mutateAsync, isPending } = useLogin();
  const [form] = Form.useForm();

  const onFinish = async (values) => {
    const formData = convertToFormData(values);
    await mutateAsync(formData);
    form.resetFields();
  };

  const FormContainer = () => (
    <Loading isLoading={isPending}>
      <Form
        form={form}
        layout="vertical"
        name="normal_login"
        className="login-form"
        onFinish={onFinish}
      >
        <SigninForm />
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={isPending}
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

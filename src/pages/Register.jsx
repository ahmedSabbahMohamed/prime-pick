import { Button, Form } from "antd";
import Loading from "../components/ui/Loading";
import RegisterForm from "../auth/components/form/RegisterForm";
import AuthModule from "../auth/components/ui/AuthModule";

function Register() {
  const FormContainer = () => (
    <Loading isLoading={false}>
      <Form layout="vertical" name="normal_register" className="register-form">
        <RegisterForm />
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={false}
            size="large"
          >
            {"Register"}
          </Button>
        </Form.Item>
      </Form>
    </Loading>
  );

  return (
    <AuthModule AUTH_TITLE={"Register"}>
      <FormContainer />
    </AuthModule>
  );
}

export default Register;

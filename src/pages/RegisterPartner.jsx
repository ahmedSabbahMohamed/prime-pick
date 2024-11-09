import { Button, Form } from "antd";
import Loading from "../components/ui/Loading";
import { useRegister } from "../features/partner/services/partnerQueries";
import convertToFormData from "../utils/convertToFormData";
import RegisterForm from "../features/partner/components/form/RegisterForm";
import AuthModule from "../features/auth/components/ui/AuthModule";

function RegisterPartner() {
  const { mutateAsync, isPending } = useRegister();
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
        name="normal_register"
        className="register-form"
        onFinish={onFinish}
      >
        <RegisterForm />
        <Form.Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={isPending}
            size="large"
          >
            {"Register"}
          </Button>
        </Form.Item>
      </Form>
    </Loading>
  );

  return (
    <AuthModule AUTH_TITLE="Register As Partner">
      <FormContainer />
    </AuthModule>
  );
}

export default RegisterPartner;

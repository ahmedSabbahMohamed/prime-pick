import { Form } from "antd";
import { useLogin } from "../features/partner/services/partnerQueries";
import convertToFormData from "../utils/convertToFormData";
import Loading from "../components/ui/Loading";
import { Button } from "antd";
import AuthModule from "../features/auth/components/ui/AuthModule";
import SigninForm from "../features/auth/components/form/SigninForm";

function SigninPartner() {
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

export default SigninPartner;

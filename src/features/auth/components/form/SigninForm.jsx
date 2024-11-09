import { LockOutlined, UserOutlined } from "@ant-design/icons";
import { Form, Input } from "antd";

function SigninForm() {
  return (
    <>
      <Form.Item
        label={"email"}
        name="email"
        rules={[
          {
            required: true,
          },
          {
            type: "email",
          },
        ]}
      >
        <Input
          prefix={<UserOutlined className="site-form-item-icon" />}
          placeholder={"email"}
          type="email"
          size="large"
        />
      </Form.Item>
      <Form.Item
        label={"password"}
        name="password"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input.Password
          prefix={<LockOutlined className="site-form-item-icon" />}
          placeholder={"password"}
          size="large"
        />
      </Form.Item>
    </>
  );
}

export default SigninForm;

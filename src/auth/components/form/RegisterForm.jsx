import { useState } from "react";
import { usePhone } from "../../services";
import { LockOutlined, MailOutlined, UserOutlined } from "@ant-design/icons";
import { Form, Input } from "antd";
import PhoneInput from "react-phone-input-2";
import "react-phone-input-2/lib/style.css";

function RegisterForm() {
  const [countryCode, setCountryCode] = useState("us");
  const [phoneNumber, setPhoneNumber] = useState("");

  const { data } = usePhone();

  data && setCountryCode(data?.data?.countryCode.toLowerCase());

  return (
    <>
      <Form.Item
        name="name"
        label={"User name"}
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input
          prefix={<UserOutlined className="site-form-item-icon" />}
          size="large"
        />
      </Form.Item>
      <Form.Item
        name="email"
        label={"Email"}
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
          prefix={<MailOutlined className="site-form-item-icon" />}
          type="Email"
          size="large"
        />
      </Form.Item>
      <Form.Item
        name="password"
        label={"Password"}
        rules={[
          {
            required: true,
          },
          {
            min: 12,
            message: "Password must be at least 12 characters",
          },
        ]}
      >
        <Input.Password
          prefix={<LockOutlined className="site-form-item-icon" />}
          size="large"
        />
      </Form.Item>
      <Form.Item
        name="phone"
        label={"Phone"}
        rules={[
          {
            required: true,
          },
        ]}
      >
        <PhoneInput
          country={countryCode}
          value={phoneNumber}
          onChange={(phone) => setPhoneNumber(phone)}
          inputStyle={{ width: "100%" }}
          countryCodeEditable={true}
        />
      </Form.Item>
    </>
  );
}

export default RegisterForm;

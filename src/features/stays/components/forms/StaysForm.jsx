import { Form } from "antd";
import convertToFormData from "../../../../utils/convertToFormData";

function StaysForm() {
  const [form] = Form.useForm();
  const onFinish = async (values) => {
    const formData = convertToFormData(values);
  };

  return (
    <Form form={form} name="stays-form" onFinish={onFinish}>
      <Form.Item>
        <Button
          type="primary"
          htmlType="submit"
          className="stays-form-button"
          loading={false}
          size="large"
        >
          {"Search"}
        </Button>
      </Form.Item>
    </Form>
  );
}

export default StaysForm;

import { notification } from "antd";

const successHandler = (message) => {
  notification.success({
    message: "Success",
    description: message,
    placement: "topRight",
    duration: 3,
  });
};

export default successHandler;

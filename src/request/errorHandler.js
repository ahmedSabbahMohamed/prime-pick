import { notification } from "antd";

const errorHandler = (status, message) => {
  const notificationMessage =
    status === "error" ? "Error Occurred" : "Request Failed";

  notification.config({
    duration: 15,
    maxCount: 1,
  });

  notification.error({
    message: notificationMessage,
    description: message,
  });
};

export default errorHandler;

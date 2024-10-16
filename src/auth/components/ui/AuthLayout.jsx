import { Col, Layout, Row } from "antd";
import booking from "../../../assets/images/booking.svg";

function AuthLayout({ children }) {
  return (
    <Layout>
      <Row>
        <Col
          xs={{ span: 0, order: 2 }}
          sm={{ span: 0, order: 2 }}
          md={{ span: 11, order: 1 }}
          lg={{ span: 12, order: 1 }}
          className="bg-gray-50 flex items-center justify-center h-[calc(100vh-60px)]"
        >
          <img src={booking} alt="Booking" />
        </Col>
        <Col
          xs={{ span: 24, order: 1 }}
          sm={{ span: 24, order: 1 }}
          md={{ span: 13, order: 2 }}
          lg={{ span: 12, order: 2 }}
          className="h-[calc(100vh-60px)] bg-white"
        >
          {children}
        </Col>
      </Row>
    </Layout>
  );
}

export default AuthLayout;

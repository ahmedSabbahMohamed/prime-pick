import { Col, Layout, Row } from "antd";
import booking from "../../../../assets/images/booking.svg";

function AuthLayout({ children }) {
  return (
    <Layout>
      <Row>
        <Col
          xs={{ span: 0 }}
          sm={{ span: 0 }}
          md={{ span: 11 }}
          lg={{ span: 12 }}
          className="bg-gray-50 flex items-center justify-center w-full"
        >
          <img src={booking} alt="Booking" />
        </Col>
        <Col
          xs={{ span: 24 }}
          sm={{ span: 24 }}
          md={{ span: 13 }}
          lg={{ span: 12 }}
          className="h-auto md:h-screen bg-white"
        >
          {children}
        </Col>
      </Row>
    </Layout>
  );
}

export default AuthLayout;

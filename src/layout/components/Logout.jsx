import { LogoutOutlined } from "@ant-design/icons";
import { Button, Tooltip } from "antd";
import { useDispatch } from "react-redux";
import { handleLogout } from "../../features/auth/store/userSlice";


function Logout() {
    
    const dispatch = useDispatch();

    const logout = () => {
        dispatch(handleLogout())
    }

  return (
    <Tooltip title="Logout">
        <Button onClick={logout} color="danger" shape="circle" variant="solid" icon={<LogoutOutlined />} />
    </Tooltip>
  );
}

export default Logout;

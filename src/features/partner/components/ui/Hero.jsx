import { REGISTER_FOR_FREE } from "../../../../utils/constants";
import { CheckCircleOutlined } from "@ant-design/icons";
import { Button } from "antd";
import { Link } from "react-router-dom";

function Hero() {
  return (
    <div className="grid grid-cols-1 md:grid-cols-12 justify-between items-center h-[calc(100vh-124px)] relative pb-10">
      <div className="text-center md:text-left col-span-6">
        <div className="text-5xl text-white mb-4 flex flex-col items-center md:items-start">
          <p>List</p>
          <p>anything</p>
          <p>on GoReserve</p>
        </div>
        <p className="text-white text-2xl">
          Whether hosting is your sideline passion or full-time job, list your
          home today and quickly start earning more income.
        </p>
      </div>
      <div className="border-4 border-yellow rounded-lg p-5 bg-white col-span-4 md:col-span-4 md:col-end-13 justify-self-end md:mx-0 mx-auto">
        <h2 className="font-bold text-xl mb-5">Register for free</h2>
        <ul className="space-y-3 mb-8">
          {REGISTER_FOR_FREE.map((item) => (
            <li key={item?.id} className="flex gap-3 items-start text-sm">
              <CheckCircleOutlined className="text-green-700 text-2xl" />
              <span>{item?.text}</span>
            </li>
          ))}
        </ul>
        <Link to={"/partner-register"}>
          <Button className="w-full" type={"primary"} size="large">
            Get started now
          </Button>
        </Link>
      </div>
      <div className="absolute -bottom-5 left-1/2 animate-bounce">
        <svg width="23" height="50" xmlns="http://www.w3.org/2000/svg">
          <g fill="none" fill-rule="evenodd">
            <g stroke="#fff" stroke-width="2">
              <rect
                opacity=".5"
                x="1"
                y="1"
                width="21"
                height="28"
                rx="10.5"
              ></rect>
              <path d="M11.5 6.5v6" stroke-linecap="square"></path>
            </g>
            <g fill="#fff" fill-rule="nonzero">
              <path
                fill-opacity=".5"
                d="M18.5 36.79300933L11.9845625 42.5 5.5 36.79300933l1.0911875-1.29259846 5.393375 4.69789282L17.37753125 35.5z"
              ></path>
              <path d="M18.5 43.79300933L11.9845625 49.5 5.5 43.79300933l1.0911875-1.29259846 5.393375 4.69789283L17.37753125 42.5z"></path>
            </g>
          </g>
        </svg>
      </div>
    </div>
  );
}

export default Hero;

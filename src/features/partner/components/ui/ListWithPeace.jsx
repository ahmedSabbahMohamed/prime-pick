import { CheckCircleOutlined } from "@ant-design/icons";
import { LIST_WITH_PEACE_OF_MIND } from "../../constants";

function ListWithPeace() {
  return (
    <div className="container mx-auto px-2 md:px-0 py-10" id="#one">
      <h2 className="text-[#1A1A1A] text-5xl font-bold leading-[62px] mb-8">
        List with peace of mind
      </h2>
      <ul className="flex flex-row flex-wrap gap-5 justify-between items-start">
        {LIST_WITH_PEACE_OF_MIND.map((item) => (
          <li key={item.id} className="flex gap-5 items-start">
            <CheckCircleOutlined className="text-slate-700 text-2xl mt-2" />
            <div className="max-w-[478px] h-[76px]">
              <h3 className="text-[#1A1A1A] text-2xl font-semibold">
                {item.title}
              </h3>
              <p>{item.text}</p>
            </div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default ListWithPeace;

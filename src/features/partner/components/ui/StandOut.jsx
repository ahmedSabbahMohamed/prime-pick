import { STAND_OUT_FROM_THE_START } from "../../constants";

function StandOut() {
  return (
    <div className="container mx-auto px-2 md:px-0">
      <h2 className="text-[#1A1A1A] text-5xl font-bold leading-[62px] mb-8">
        Stand out from the start
      </h2>
      <ul className="flex flex-row flex-wrap gap-4 justify-between items-start">
        {STAND_OUT_FROM_THE_START.map((item) => (
          <li key={item.id} className="flex gap-5 items-start max-w-[381px]">
            <div className="">
              <img src={item.icon} alt="stand-icon" />
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

export default StandOut
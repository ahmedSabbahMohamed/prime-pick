import { PARTNER_SUB_HEADER } from "../../constants";

function SubHeader() {
  return (
    <div className="bg-neutral-100 shadow sticky top-0 z-10">
      <div className="h-[66px] flex items-center justify-center container mx-auto">
        <ul className="flex items-center gap-8 overflow-auto h-full">
          {PARTNER_SUB_HEADER.map((item) => {
            return (
              <li
                className="text-[#1A1A1A] text-[13.781px] font-normal leading-7 text-nowrap border-b border-transparent h-full flex items-center justify-center"
                key={item.id}
              >
                <a href={item.href}>{item.text}</a>
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
}

export default SubHeader;

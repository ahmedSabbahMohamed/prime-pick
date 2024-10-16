import { Link } from "react-router-dom";
import { HEADER_NAV } from "../../utils/constants";

function HeaderNav() {
  const NavLink = ({ link, text, Icon }) => {
    return (
      <li className="h-[42px] px-4 rounded-full border border-transparent active:bg-blue-800 active:border-white">
        <Link
          to={link}
          className="flex justify-center items-center gap-1 w-full h-full"
        >
          <span>
            <Icon size={"20px"} color={"white"} />
          </span>
          <span className="text-white text-sm font-normal whitespace-nowrap">
            {text}
          </span>
        </Link>
      </li>
    );
  };

  return (
    <nav>
      <ul className="flex gap-2 overflow-x-auto shrink-0 grow-0 pb-3">
        {HEADER_NAV.map((item, index) => (
          <NavLink key={index} link={item.link} text={item.text} Icon={item.icon} />
        ))}
      </ul>
    </nav>
  );
}

export default HeaderNav;

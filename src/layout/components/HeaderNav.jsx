import { NavLink } from "react-router-dom";
import { HEADER_NAV } from "../../utils/constants";

function HeaderNav() {
  const NavLinkItem = ({ link, text, Icon }) => {
    return (
      <li>
        <NavLink
          to={link}
          className={({ isActive }) =>
            `flex gap-1 items-center h-[45px] px-2 rounded-full border ${
              isActive ? "bg-blue-700" : "border-transparent"
            }`
          }
        >
          <span>
            <Icon size={"20px"} color={"white"} />
          </span>
          <span className="text-white text-sm font-normal whitespace-nowrap">
            {text}
          </span>
        </NavLink>
      </li>
    );
  };

  return (
    <nav>
      <ul className="flex gap-2 overflow-x-auto shrink-0 grow-0 pb-3">
        {HEADER_NAV.map((item, index) => (
          <NavLinkItem
            key={index}
            link={item.link}
            text={item.text}
            Icon={item.icon}
          />
        ))}
      </ul>
    </nav>
  );
}

export default HeaderNav;

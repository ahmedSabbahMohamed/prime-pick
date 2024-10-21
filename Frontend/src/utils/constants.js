import { BsTaxiFrontFill } from "react-icons/bs";
import { MdOutlineAttractions } from "react-icons/md";
import { IoCarSportOutline } from "react-icons/io5";
import { MdOutlineBed } from "react-icons/md";
import { LuPlaneTakeoff } from "react-icons/lu";

export const HEADER_NAV = [
  {
    link: "/",
    text: "Stays",
    icon: MdOutlineBed,
  },
  {
    link: "flights",
    text: "Flights",
    icon: LuPlaneTakeoff,
  },
  {
    link: "car-rentals",
    text: "Car rentals",
    icon: IoCarSportOutline,
  },
  {
    link: "attractions",
    text: "Attractions",
    icon: MdOutlineAttractions,
  },
  {
    link: "airport-taxis",
    text: "Airport taxis",
    icon: BsTaxiFrontFill,
  },
];

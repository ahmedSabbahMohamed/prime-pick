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

export const REGISTER_FOR_FREE = [
  {
    id: 1,
    text: "45% of hosts get their first booking within a week",
  },
  {
    id: 2,
    text: "Choose between instant bookings and booking requests",
  },
  {
    id: 3,
    text: "We handle payments for you",
  },
];
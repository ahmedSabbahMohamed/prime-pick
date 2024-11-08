import React from "react";
import Logo from "../../components/ui/Logo";
import AuthButtons from "../components/AuthButtons";
import HeaderNav from "../components/HeaderNav";

function Header() {
  return (
    <div className="bg-primary">
      <header className="container mx-auto px-2 md:px-0">
        <div className="flex items-center justify-between h-[60px]">
          <Logo />
          <AuthButtons />
        </div>
        <HeaderNav />
      </header>
    </div>
  );
}

export default Header;

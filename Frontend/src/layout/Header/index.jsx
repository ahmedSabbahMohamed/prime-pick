import React from "react";
import Logo from "../../components/ui/Logo";
import AuthButtons from "../components/AuthButtons";
import HeaderNav from "../components/HeaderNav";

function Header() {
  return (
    <div className="bg-primary">
      <header className="container mx-auto min-h-[60px] px-2 py-5">
        <div className="flex flex-row justify-between items-center mb-8">
          <Logo />
          <AuthButtons />
        </div>
        <HeaderNav />
      </header>
    </div>
  );
}

export default Header;

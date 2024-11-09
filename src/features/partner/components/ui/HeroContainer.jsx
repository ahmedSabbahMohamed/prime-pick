import Header from "./Header";
import Hero from "./Hero";

function HeroContainer() {
  return (
    <div className="bg-primary">
      <div className="container mx-auto px-2 md:px-0">
        <div>
          <Header />
        </div>
        <Hero />
      </div>
    </div>
  );
}

export default HeroContainer;

function Hero({ title, subtitle, content: Content }) {
  return (
    <section className="min-h-[240px] relative bg-primary flex items-center">
      <div className="container mx-auto px-2 md:px-0">
        <h2 className="text-white text-5xl font-extrabold">{title}</h2>
        <p className="text-2xl text-white">{subtitle}</p>
        <div className="absolute bg-yellow w-full rounded min-h-[62px] p-1">
          <Content />
        </div>
      </div>
    </section>
  );
}

export default Hero;

import AuthLayout from "./AuthLayout";

function AuthModule({ children, AUTH_TITLE }) {
  return (
    <AuthLayout>
      <div className="flex flex-col items-center justify-center min-h-full">
        <h2 className="text-primary text-3xl text-center my-8 font-bold">
          {AUTH_TITLE}
        </h2>
        <div className="w-80">{children}</div>
      </div>
    </AuthLayout>
  );
}

export default AuthModule;

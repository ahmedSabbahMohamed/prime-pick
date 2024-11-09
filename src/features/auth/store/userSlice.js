import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
  name: "user",
  initialState: {
    isLogin: false,
    user: {},
  },
  reducers: {
    handleLogin: (state, action) => {
      state.isLogin = true;
      const user = action.payload;
      state.user = user;
      localStorage.setItem("ACCESS_TOKEN", user.access_token);
      localStorage.setItem("REFRESH_TOKEN", user.refresh_token);
      window.location.pathname = "/";
    },
    handleLogout: (state) => {
      state.isLogin = false;
      state.user = {};
      localStorage.clear();
      window.location.pathname = "/sign-in";
    },
  },
});

export const { handleLogin, handleLogout } = userSlice.actions;
export default userSlice.reducer;

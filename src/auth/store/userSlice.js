import { createSlice } from "@reduxjs/toolkit";

export const userSlice = createSlice({
  name: "user",
  initialState: {
    isLogin: false,
    user: {},
  },
  reducers: {
    handleLogin: (state, action) => {},
    handleLogout: (state) => {},
  },
});

export const { handleLogin, handleLogout } = userSlice.actions;
export default userSlice.reducer;

import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { persistReducer, persistStore } from "redux-persist";
import storage from "redux-persist/lib/storage";
import { reducers } from "../reducers";

const persistConfig = {
  key: "root",
  storage: storage,
};

const baseReducers = combineReducers(reducers);

const pReducer = persistReducer(persistConfig, baseReducers);

export const store = configureStore({reducer: pReducer});
export const persistor = persistStore(store);

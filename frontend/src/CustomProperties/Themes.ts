import { configureFonts, DefaultTheme, DarkTheme } from "react-native-paper";
import {
  DefaultTheme as DefaultThemeNavigation,
  DarkTheme as DarkThemeNavigation,
} from "@react-navigation/native";
import customFonts from "./Fonts";

export const defaultTheme = {
  ...DefaultTheme,
  ...DefaultThemeNavigation,
  fonts: configureFonts({ default: customFonts }),
  roundness: 30,
  colors: {
    ...DefaultTheme.colors,
    ...DefaultThemeNavigation.colors,
    // primary: "#4169E1",
    // accent: "#f1c40f",
    // favorite: "#BADA55",
    // cancelButton: "#a4c639",
    // iconColor: "#808080",
  },
};

export const darkTheme = {
  ...DarkTheme,
  ...DarkThemeNavigation,
  fonts: configureFonts({ default: customFonts }),
  roundness: 30,
  colors: {
    ...DarkTheme.colors,
    ...DarkThemeNavigation.colors,
  },
};

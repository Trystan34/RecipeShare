import * as React from "react";
import { DrawerNavigationProp } from "@react-navigation/drawer";
import { TouchableOpacity } from "react-native-gesture-handler";
import { Appbar, Avatar, useTheme } from "react-native-paper";
import { MaterialCommunityIcons } from "@expo/vector-icons";
import {
  Scene,
  StackNavigationProp,
} from "@react-navigation/stack/lib/typescript/src/types";
import { ParamListBase, Route } from "@react-navigation/native";

interface IStackHeaderProps {
  scene: Scene<Route<string, object | undefined>>;
  previous: Scene<Route<string, object | undefined>> | undefined;
  navigation: StackNavigationProp<ParamListBase, string>;
}

const defaultProfile = require("../../../assets/images/blank-profile-picture.png");

const StackHeader = ({ scene, previous, navigation }: IStackHeaderProps) => {
  const theme = useTheme();
  const { options } = scene.descriptor;
  const title =
    options.headerTitle !== undefined
      ? options.headerTitle
      : options.title !== undefined
      ? options.title
      : scene.route.name;

  return (
    <Appbar.Header theme={{ colors: { primary: theme.colors.surface } }}>
      {previous ? (
        <Appbar.BackAction
          onPress={navigation.goBack}
          color={theme.colors.primary}
        />
      ) : (
        <TouchableOpacity
          style={{ marginLeft: 10 }}
          onPress={() => {
            (navigation as any as DrawerNavigationProp<{}>).openDrawer();
          }}
        >
          <Avatar.Image size={40} source={defaultProfile} />
        </TouchableOpacity>
      )}
      <Appbar.Content
        title={
          previous ? (
            title
          ) : title === "Home" ? (
            <MaterialCommunityIcons
              style={{ marginRight: 10 }}
              name="leaf"
              size={40}
              color={theme.colors.primary}
            />
          ) : (
            title
          )
        }
        titleStyle={{
          fontSize: 18,
          fontWeight: "bold",
          color: theme.colors.primary,
          alignSelf: title === "Home" ? "center" : "auto",
        }}
      />
    </Appbar.Header>
  );
};

export default StackHeader;

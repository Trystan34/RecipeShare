import * as React from "react";
import { overlay } from "react-native-paper";
import { Home, Profile, Cookbook } from "../../Screens";
import { createMaterialBottomTabNavigator } from "@react-navigation/material-bottom-tabs";
import { useTheme, Portal, FAB } from "react-native-paper";
import { useSafeAreaInsets } from "react-native-safe-area-context";
import {
  getFocusedRouteNameFromRoute,
  RouteProp,
  useIsFocused,
} from "@react-navigation/native";
import { RootStackParamList } from "../../Routing";

const Tab = createMaterialBottomTabNavigator();

type Props = {
  route: RouteProp<RootStackParamList, "Home">;
};

const BottomBar: React.FC<Props> = ({ route }) => {
  const theme = useTheme();
  const safeArea = useSafeAreaInsets();
  const isFocused = useIsFocused();
  const routeName = getFocusedRouteNameFromRoute(route) ?? "Home";

  let icon = "plus";

  switch (routeName) {
    case "Cookbook":
      icon = "bookmark";
      break;
    default:
      icon = "plus";
      break;
  }

  const tabBarColor = theme.dark
    ? (overlay(6, theme.colors.surface) as string)
    : theme.colors.surface;

  return (
    <React.Fragment>
      <Tab.Navigator
        initialRouteName="Home"
        backBehavior="initialRoute"
        shifting={true}
        activeColor={theme.colors.primary}
        inactiveColor={theme.colors.backdrop}
        sceneAnimationEnabled={false}
      >
        <Tab.Screen
          name="Home"
          component={Home}
          options={{
            tabBarIcon: "home",
            tabBarColor,
          }}
        />
        <Tab.Screen
          name="Cookbook"
          component={Cookbook}
          options={{
            tabBarIcon: "book-open",
            tabBarColor,
          }}
        />
      </Tab.Navigator>
      <Portal>
        <FAB
          visible={isFocused}
          icon={icon}
          style={{
            position: "absolute",
            bottom: safeArea.bottom + 65,
            right: 16,
          }}
          color="white"
          theme={{
            colors: {
              accent: theme.colors.primary,
            },
          }}
          onPress={() => {
            console.log("Create recipe");
          }}
        />
      </Portal>
    </React.Fragment>
  );
};

export default BottomBar;

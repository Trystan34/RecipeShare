import * as React from "react";
import { createStackNavigator } from "@react-navigation/stack";
import { getFocusedRouteNameFromRoute } from "@react-navigation/native";
import { RootStackParamList } from "../../Routing";
import { Details } from "../../Screens/";
import { StackHeader, BottomBar } from ".";

const Stack = createStackNavigator<RootStackParamList>();

const StackNavigator = () => {
  return (
    <Stack.Navigator
      initialRouteName="Home"
      headerMode="screen"
      screenOptions={{
        header: ({ scene, previous, navigation }) => (
          <StackHeader
            scene={scene}
            previous={previous}
            navigation={navigation}
          />
        ),
      }}
    >
      <Stack.Screen
        name="Home"
        component={BottomBar}
        options={({ route }) => {
          const routeName = getFocusedRouteNameFromRoute(route) ?? "Home";
          return { headerTitle: routeName };
        }}
      />
      <Stack.Screen
        name="Details"
        component={Details}
        options={{ headerTitle: "Details" }}
      />
    </Stack.Navigator>
  );
};

export default StackNavigator;

import * as React from "react";
import { Appbar, Button, Switch, TouchableRipple } from "react-native-paper";
import Icon from "@expo/vector-icons/MaterialCommunityIcons";
import { PreferencesContext } from "../../CustomProperties/PreferencesContext";

interface ITopBarProps {}

const TopBar: React.FC<ITopBarProps> = ({ ...props }) => {
  const { toggleTheme, isThemeDark } = React.useContext(PreferencesContext);

  return (
    <Appbar.Header>
      <Appbar.Content title="Recipe Share"></Appbar.Content>
      {/* <Button mode="contained" onPress={() => console.log("Pressed")}>
        Register <Icon name="twitter-retweet" />
      </Button> */}
      <TouchableRipple onPress={() => toggleTheme()}>
        <Switch value={isThemeDark} />
      </TouchableRipple>
      {isThemeDark ? <span>☀️</span> : <span>🌙</span>}
    </Appbar.Header>
  );
};

export default TopBar;

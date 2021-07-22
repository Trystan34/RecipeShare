import * as React from "react";
import "react-native-gesture-handler";
import { defaultTheme, darkTheme } from "./CustomProperties/Themes";
import { Provider as PaperProvider } from "react-native-paper";
import { PreferencesContext } from "./CustomProperties/PreferencesContext";
import { RootNavigator } from "./Components/Navigation";
import { ApolloProvider } from "@apollo/client";
import { Apollo } from "./GraphQL";

const Main = () => {
  const [isThemeDark, setIsThemeDark] = React.useState(true);

  let theme = isThemeDark ? darkTheme : defaultTheme;

  const toggleTheme = React.useCallback(() => {
    return setIsThemeDark(!isThemeDark);
  }, [isThemeDark]);

  const preferences = React.useMemo(
    () => ({
      toggleTheme,
      isThemeDark,
    }),
    [toggleTheme, isThemeDark]
  );

  return (
    <ApolloProvider client={Apollo}>
      <PreferencesContext.Provider value={preferences}>
        <PaperProvider theme={theme}>
          <RootNavigator />
        </PaperProvider>
      </PreferencesContext.Provider>
    </ApolloProvider>
  );
};

export default Main;

import * as React from "react";
import { SearchBar } from "../Components/Navigation";
import { Container } from "../Components/Layout";
import { StackNavigationProp } from "@react-navigation/stack";
import { RootStackParamList } from "../Routing";
import RecipeList from "../Components/Recipe/RecipeList";

type HomeScreenNavigationProp = StackNavigationProp<RootStackParamList, "Home">;

type HomeScreenProps = {
  navigation?: HomeScreenNavigationProp;
};

/**
 * Home screen displays a list of public recipes
 * @param param0
 * @returns
 */
const Home: React.FC<HomeScreenProps> = ({ navigation }) => {
  return (
    <Container>
      <SearchBar />
      <RecipeList navigation={navigation} />
    </Container>
  );
};

export default Home;

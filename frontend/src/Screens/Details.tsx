import * as React from "react";
import { RouteProp } from "@react-navigation/native";

import { RecipeDetails } from "../Components/Recipe";
import { RootStackParamList } from "../Routing";

type Props = {
  route: RouteProp<RootStackParamList, "Details">;
};

const Details = (props: Props) => {
  return <RecipeDetails {...props.route.params} />;
};

export default Details;

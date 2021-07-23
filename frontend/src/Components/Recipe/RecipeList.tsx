import * as React from "react";
import { ActivityIndicator, useTheme } from "react-native-paper";
import { FlatList, View } from "react-native";
import { Recipe } from "../../Types";
import { StyleSheet } from "react-native";
import { RecipeListItem } from "../../Components/Recipe";
import { useGetRecipesQuery } from "../../GraphQL/graphql";

type RecipeProps = React.ComponentProps<typeof RecipeListItem>;

function renderItem({ item }: { item: RecipeProps }) {
  return <RecipeListItem {...item} />;
}

function keyExtractor(item: RecipeProps) {
  return item.id.toString();
}

interface IRecipeListProps {
  navigation: any;
}

const RecipeList: React.FC<IRecipeListProps> = ({ navigation }) => {
  const theme = useTheme();

  const { data, error, loading } = useGetRecipesQuery();
  // const { data, error, loading } = useGetRecipeQuery({
  //   variables: { id: "e7448fc2-1cbe-48ad-a69e-deda6ca38ddb" },
  // });

  if (error) {
    console.log("Error getting recipes", error);
  }

  let recipeData = undefined;

  if (data && data.recipes) {
    const recipes: Omit<{ id: string; name: string }, "onPress">[] = [];
    data.recipes.forEach((recipe: any) => {
      recipes.push({ id: recipe.id, name: recipe.name });
    });

    recipeData = recipes.map((recipe: Recipe) => ({
      ...recipe,
      onPress: () =>
        navigation &&
        navigation.push("Details", {
          ...recipe,
        }),
    }));
  }

  return (
    <>
      {loading ? (
        <ActivityIndicator />
      ) : (
        <>
          {data && (
            <View style={{ flex: 1, justifyContent: "center" }}>
              <FlatList
                contentContainerStyle={{
                  backgroundColor: theme.colors.background,
                }}
                style={{ backgroundColor: theme.colors.background }}
                data={recipeData}
                renderItem={renderItem}
                keyExtractor={keyExtractor}
                ItemSeparatorComponent={() => (
                  <View style={{ height: StyleSheet.hairlineWidth }} />
                )}
              />
            </View>
          )}
        </>
      )}
    </>
  );
};

export default RecipeList;

import { gql } from "@apollo/client";

class QueryManager {
  public static GET_RECIPES = gql`
    query GetRecipes {
      recipes {
        id
        name
        category {
          id
          name
        }
      }
    }
  `;

  public static GET_RECIPE = gql`
    query GetRecipe($id: ID!) {
      recipe(id: $id) {
        id
        name
        category {
          id
          name
        }
      }
    }
  `;
}

export default QueryManager;

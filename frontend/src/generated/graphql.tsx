import { gql } from "@apollo/client";
import * as Apollo from "@apollo/client";
export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = {
  [K in keyof T]: T[K];
};
export type MakeOptional<T, K extends keyof T> = Omit<T, K> &
  { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> &
  { [SubKey in K]: Maybe<T[SubKey]> };
const defaultOptions = {};
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  Guid: any;
};

export type MainMutation = {
  __typename?: "MainMutation";
  addRecipe?: Maybe<RecipeType>;
  deleteRecipe?: Maybe<Scalars["String"]>;
  addCategory?: Maybe<RecipeCategoryType>;
  updateRecipe?: Maybe<RecipeType>;
  mainMutation?: Maybe<Scalars["String"]>;
};

export type MainMutationAddRecipeArgs = {
  recipeName: Scalars["String"];
  categoryId: Scalars["Guid"];
};

export type MainMutationDeleteRecipeArgs = {
  id: Scalars["Guid"];
};

export type MainMutationAddCategoryArgs = {
  name: Scalars["String"];
  description?: Maybe<Scalars["String"]>;
};

export type MainMutationUpdateRecipeArgs = {
  id: Scalars["Guid"];
  name?: Maybe<Scalars["String"]>;
  categoryId?: Maybe<Scalars["Guid"]>;
};

export type MainQuery = {
  __typename?: "MainQuery";
  recipeCategories?: Maybe<Array<Maybe<RecipeCategoryType>>>;
  recipes?: Maybe<Array<Maybe<RecipeType>>>;
  mainQuery?: Maybe<Scalars["String"]>;
};

export type MainQueryRecipeCategoriesArgs = {
  name?: Maybe<Scalars["String"]>;
};

export type MainQueryRecipesArgs = {
  name?: Maybe<Scalars["String"]>;
};

export type MainSubscription = {
  __typename?: "MainSubscription";
  recipeAdded?: Maybe<RecipeAddedMessageType>;
  mainSubscription?: Maybe<Scalars["String"]>;
};

export type MainSubscriptionRecipeAddedArgs = {
  name: Scalars["String"];
};

export type RecipeAddedMessageType = {
  __typename?: "RecipeAddedMessageType";
  id?: Maybe<Scalars["Guid"]>;
  message?: Maybe<Scalars["String"]>;
  recipeName?: Maybe<Scalars["String"]>;
  categoryName?: Maybe<Scalars["String"]>;
};

export type RecipeCategoryType = {
  __typename?: "RecipeCategoryType";
  id?: Maybe<Scalars["Guid"]>;
  name?: Maybe<Scalars["String"]>;
  description?: Maybe<Scalars["String"]>;
  recipes?: Maybe<Array<Maybe<RecipeType>>>;
};

export type RecipeType = {
  __typename?: "RecipeType";
  id?: Maybe<Scalars["Guid"]>;
  name?: Maybe<Scalars["String"]>;
  categoryId?: Maybe<Scalars["Guid"]>;
  category?: Maybe<RecipeCategoryType>;
};

export type Get_RecipesQueryVariables = Exact<{ [key: string]: never }>;

export type Get_RecipesQuery = { __typename?: "MainQuery" } & {
  recipes?: Maybe<
    Array<
      Maybe<
        { __typename?: "RecipeType" } & Pick<RecipeType, "id" | "name"> & {
            category?: Maybe<
              { __typename?: "RecipeCategoryType" } & Pick<
                RecipeCategoryType,
                "id" | "name"
              >
            >;
          }
      >
    >
  >;
};

export const Get_RecipesDocument = gql`
  query GET_RECIPES {
    recipes {
      id
      name
    }
  }
`;

/**
 * __useGet_RecipesQuery__
 *
 * To run a query within a React component, call `useGet_RecipesQuery` and pass it any options that fit your needs.
 * When your component renders, `useGet_RecipesQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGet_RecipesQuery({
 *   variables: {
 *   },
 * });
 */
export function useGet_RecipesQuery(
  baseOptions?: Apollo.QueryHookOptions<
    Get_RecipesQuery,
    Get_RecipesQueryVariables
  >
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useQuery<Get_RecipesQuery, Get_RecipesQueryVariables>(
    Get_RecipesDocument,
    options
  );
}
export function useGet_RecipesLazyQuery(
  baseOptions?: Apollo.LazyQueryHookOptions<
    Get_RecipesQuery,
    Get_RecipesQueryVariables
  >
) {
  const options = { ...defaultOptions, ...baseOptions };
  return Apollo.useLazyQuery<Get_RecipesQuery, Get_RecipesQueryVariables>(
    Get_RecipesDocument,
    options
  );
}
export type Get_RecipesQueryHookResult = ReturnType<typeof useGet_RecipesQuery>;
export type Get_RecipesLazyQueryHookResult = ReturnType<
  typeof useGet_RecipesLazyQuery
>;
export type Get_RecipesQueryResult = Apollo.QueryResult<
  Get_RecipesQuery,
  Get_RecipesQueryVariables
>;

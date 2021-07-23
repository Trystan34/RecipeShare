import { gql } from '@apollo/client';
import * as Apollo from '@apollo/client';
export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
const defaultOptions =  {}
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
  __typename?: 'MainMutation';
  addRecipe?: Maybe<RecipeType>;
  deleteRecipe?: Maybe<Scalars['String']>;
  addCategory?: Maybe<RecipeCategoryType>;
  updateRecipe?: Maybe<RecipeType>;
  mainMutation?: Maybe<Scalars['String']>;
};


export type MainMutationAddRecipeArgs = {
  recipeName: Scalars['String'];
  categoryId: Scalars['Guid'];
};


export type MainMutationDeleteRecipeArgs = {
  id: Scalars['Guid'];
};


export type MainMutationAddCategoryArgs = {
  name: Scalars['String'];
  description?: Maybe<Scalars['String']>;
};


export type MainMutationUpdateRecipeArgs = {
  id: Scalars['Guid'];
  name?: Maybe<Scalars['String']>;
  categoryId?: Maybe<Scalars['Guid']>;
};

export type MainQuery = {
  __typename?: 'MainQuery';
  recipeCategories?: Maybe<Array<Maybe<RecipeCategoryType>>>;
  recipes?: Maybe<Array<Maybe<RecipeType>>>;
  mainQuery?: Maybe<Scalars['String']>;
};


export type MainQueryRecipeCategoriesArgs = {
  name?: Maybe<Scalars['String']>;
};


export type MainQueryRecipesArgs = {
  id?: Maybe<Scalars['Guid']>;
  name?: Maybe<Scalars['String']>;
};

export type MainSubscription = {
  __typename?: 'MainSubscription';
  recipeAdded?: Maybe<RecipeAddedMessageType>;
  mainSubscription?: Maybe<Scalars['String']>;
};


export type MainSubscriptionRecipeAddedArgs = {
  name: Scalars['String'];
};

export type RecipeAddedMessageType = {
  __typename?: 'RecipeAddedMessageType';
  id?: Maybe<Scalars['Guid']>;
  message?: Maybe<Scalars['String']>;
  recipeName?: Maybe<Scalars['String']>;
  categoryName?: Maybe<Scalars['String']>;
};

export type RecipeCategoryType = {
  __typename?: 'RecipeCategoryType';
  id?: Maybe<Scalars['Guid']>;
  name?: Maybe<Scalars['String']>;
  description?: Maybe<Scalars['String']>;
  recipes?: Maybe<Array<Maybe<RecipeType>>>;
};

export type RecipeType = {
  __typename?: 'RecipeType';
  id?: Maybe<Scalars['Guid']>;
  name?: Maybe<Scalars['String']>;
  categoryId?: Maybe<Scalars['Guid']>;
  category?: Maybe<RecipeCategoryType>;
};

export type GetRecipesQueryVariables = Exact<{ [key: string]: never; }>;


export type GetRecipesQuery = (
  { __typename?: 'MainQuery' }
  & { recipes?: Maybe<Array<Maybe<(
    { __typename?: 'RecipeType' }
    & Pick<RecipeType, 'id' | 'name'>
    & { category?: Maybe<(
      { __typename?: 'RecipeCategoryType' }
      & Pick<RecipeCategoryType, 'id' | 'name'>
    )> }
  )>>> }
);

export type GetRecipeQueryVariables = Exact<{
  id?: Maybe<Scalars['Guid']>;
}>;


export type GetRecipeQuery = (
  { __typename?: 'MainQuery' }
  & { recipes?: Maybe<Array<Maybe<(
    { __typename?: 'RecipeType' }
    & Pick<RecipeType, 'id' | 'name'>
    & { category?: Maybe<(
      { __typename?: 'RecipeCategoryType' }
      & Pick<RecipeCategoryType, 'id' | 'name'>
    )> }
  )>>> }
);


export const GetRecipesDocument = gql`
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

/**
 * __useGetRecipesQuery__
 *
 * To run a query within a React component, call `useGetRecipesQuery` and pass it any options that fit your needs.
 * When your component renders, `useGetRecipesQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGetRecipesQuery({
 *   variables: {
 *   },
 * });
 */
export function useGetRecipesQuery(baseOptions?: Apollo.QueryHookOptions<GetRecipesQuery, GetRecipesQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<GetRecipesQuery, GetRecipesQueryVariables>(GetRecipesDocument, options);
      }
export function useGetRecipesLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<GetRecipesQuery, GetRecipesQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<GetRecipesQuery, GetRecipesQueryVariables>(GetRecipesDocument, options);
        }
export type GetRecipesQueryHookResult = ReturnType<typeof useGetRecipesQuery>;
export type GetRecipesLazyQueryHookResult = ReturnType<typeof useGetRecipesLazyQuery>;
export type GetRecipesQueryResult = Apollo.QueryResult<GetRecipesQuery, GetRecipesQueryVariables>;
export const GetRecipeDocument = gql`
    query GetRecipe($id: Guid) {
  recipes(id: $id) {
    id
    name
    category {
      id
      name
    }
  }
}
    `;

/**
 * __useGetRecipeQuery__
 *
 * To run a query within a React component, call `useGetRecipeQuery` and pass it any options that fit your needs.
 * When your component renders, `useGetRecipeQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGetRecipeQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useGetRecipeQuery(baseOptions?: Apollo.QueryHookOptions<GetRecipeQuery, GetRecipeQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<GetRecipeQuery, GetRecipeQueryVariables>(GetRecipeDocument, options);
      }
export function useGetRecipeLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<GetRecipeQuery, GetRecipeQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<GetRecipeQuery, GetRecipeQueryVariables>(GetRecipeDocument, options);
        }
export type GetRecipeQueryHookResult = ReturnType<typeof useGetRecipeQuery>;
export type GetRecipeLazyQueryHookResult = ReturnType<typeof useGetRecipeLazyQuery>;
export type GetRecipeQueryResult = Apollo.QueryResult<GetRecipeQuery, GetRecipeQueryVariables>;
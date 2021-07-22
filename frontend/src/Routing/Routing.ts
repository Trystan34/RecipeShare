export type RootStackParamList = {
  Home: undefined;
  Profile: { userId: string };
  Cookbook: { userId: string };
  Details: { id: string; name: string; onPress?: (id: string) => void };
};

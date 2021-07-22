import * as React from "react";
import { View, Image, StyleSheet } from "react-native";
import { Surface, Caption, Subheading, Title } from "react-native-paper";

interface IRecipeDetailsProps {
  id: string;
  name: string;
  onPress?: (id: string) => void;
}

function RecipeDetails(props: IRecipeDetailsProps) {
  return (
    <Surface style={styles.container}>
      <View style={styles.topRow}>
        <View>
          <Title>{props.name}</Title>
          <Caption style={styles.handle}>Category?</Caption>
        </View>
      </View>
      <Subheading style={[styles.content]}>Content</Subheading>
      <Image
        source={{ uri: "https://picsum.photos/700" }}
        style={[styles.image]}
      />
    </Surface>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },
  avatar: {
    marginRight: 20,
  },
  topRow: {
    flexDirection: "row",
    alignItems: "center",
  },
  handle: {
    marginRight: 3,
    lineHeight: 12,
  },
  content: {
    marginTop: 25,
    fontSize: 20,
    lineHeight: 30,
  },
  image: {
    borderWidth: StyleSheet.hairlineWidth,
    marginTop: 25,
    borderRadius: 20,
    width: "100%",
    height: 280,
  },
});

export default RecipeDetails;

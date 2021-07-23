import * as React from "react";
import { StyleSheet, View, Image, useWindowDimensions } from "react-native";
import {
  Surface,
  Title,
  Subheading,
  TouchableRipple,
} from "react-native-paper";

interface IRecipeListItemProps {
  id: string;
  name: string;
  onPress?: (id: string) => void;
}

const RecipeListItem = (props: IRecipeListItemProps) => {
  const dimensions = useWindowDimensions();

  return (
    <TouchableRipple
      onPress={() => props.onPress && props.onPress(props.id)}
      style={{
        width: `${dimensions.width >= 768 ? "60%" : "100%"}`,
        paddingBottom: "1rem",
        alignSelf: "center",
      }}
    >
      <Surface style={styles.container}>
        <View style={styles.topRow}>
          <View>
            <Title>{props.name}</Title>
          </View>
        </View>
        <Image
          source={{ uri: "https://picsum.photos/700" }}
          style={[styles.image]}
        />
        <Subheading style={[styles.content]}>
          Recipe content goes here.
        </Subheading>
      </Surface>
    </TouchableRipple>
  );
};

export default RecipeListItem;

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

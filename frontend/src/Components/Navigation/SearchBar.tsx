import * as React from "react";
import { Searchbar } from "react-native-paper";
import { StyleSheet, View } from "react-native";

const SearchBar = () => {
  const [searchQuery, setSearchQuery] = React.useState("");

  const onChangeSearch = (query: any) => setSearchQuery(query);

  return (
    <View style={{ alignItems: "center" }}>
      <Searchbar
        placeholder="Search"
        onChangeText={onChangeSearch}
        value={searchQuery}
        style={styles.search}
      />
    </View>
  );
};

export default SearchBar;

const styles = StyleSheet.create({
  search: {
    marginBottom: "1rem",
  },
});

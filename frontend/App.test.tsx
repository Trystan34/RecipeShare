import * as React from "react";
import TestRenderer from "react-test-renderer";

import App from "./App";

describe("<App />", () => {
  it("has 1 child", () => {
    const tree = TestRenderer.create(<App />);

    if (tree) {
      expect(tree.root.children.length).toBe(1);
    }
  });

  it("renders correctly", () => {
    const tree = TestRenderer.create(<App />).toJSON();
    expect(tree).toMatchSnapshot();
  });
});

import * as React from "react";
import TestRenderer from "react-test-renderer";

import Cookbook from "../../src/Screens/Cookbook";

describe("<Cookbook />", () => {
  it("renders correctly", () => {
    const tree = TestRenderer.create(<Cookbook />).toJSON();
    expect(tree).toMatchSnapshot();
  });
});

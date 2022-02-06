import * as React from "react";
import { useContext, useEffect, useState } from "react";
import { Box, MenuItem, Select } from "@mui/material";
import Item from "../../MuiExtensions/Item";
import wrapAPICall from "../../GlobalState/LoadingState/wrapAPICall";
import { LoadingContext } from "../../GlobalState/LoadingState/LoadingStore";

const StorePanel = (props: any) => {
  const [loadingState, setLoadingState]: any = useContext(LoadingContext);

  useEffect(() => {
    wrapAPICall(async () => {
      const response = await fetch("", {
        method: "GET",
      });

      const result = await response.json();

      switch (response.status) {
        case 200:

        case 400:
        default:
      }
    }, setLoadingState);
  }, [])


  return (
    <Item>
      StorePanel
    </Item>
  );
};

export default StorePanel;

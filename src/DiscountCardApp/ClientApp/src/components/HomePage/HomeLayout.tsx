import * as React from "react";
import { useContext, useEffect, useState } from "react";
import { LoadingContext } from "../GlobalState/LoadingState/LoadingStore";
import wrapAPICall from "../GlobalState/LoadingState/wrapAPICall";
import { Box, MenuItem, Select } from "@mui/material";
import Item from "../MuiExtensions/Item";
import CodePanel from "./Codes/CodePanel";
import StorePanel from "./Stores/StorePanel";
import CardPanel from "./Cards/CardPanel";

const HomeLayout = (props: any) => {
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
    <Box
      sx={{
        display: 'grid',
        gap: 1,
        gridTemplateColumns: 'repeat(12, 1fr)',
        margin: '50px 100px',
      }}
    >
      <Box gridColumn="span 12"      >
        <CardPanel></CardPanel>
      </Box>
      <Box gridColumn="span 4">
        <CodePanel></CodePanel>
      </Box>
      <Box gridColumn="span 8">
        <StorePanel></StorePanel>
      </Box>
    </Box>
  );
};

export default HomeLayout;

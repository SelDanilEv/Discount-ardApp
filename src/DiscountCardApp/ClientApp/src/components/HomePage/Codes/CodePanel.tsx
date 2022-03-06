import * as React from "react";
import { useContext, useEffect, useState } from "react";
import { Box, Button, Divider, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import Item from "../../MuiExtensions/Item";
import wrapAPICall from "../../GlobalState/LoadingState/wrapAPICall";
import { LoadingContext } from "../../GlobalState/LoadingState/LoadingStore";

const CodePanel = (props: any) => {
  const [loadingState, setLoadingState]: any = useContext(LoadingContext);

  const [code, setCode] = useState<any>({});
  const [codes, setCodes] = useState<any[]>([]);

  useEffect(() => {
    wrapAPICall(loadCodesData, setLoadingState);
  }, [])

  const loadCodesData = async () => {
    const response = await fetch("api/v1/MCCCode/GetAllMCCCodes", {
      method: "GET",
    });

    const result = await response.json();

    switch (response.status) {
      case 200:
        setCodes(result);
      case 400:
      default:
    }
  }

  //--- Code region ---
  const handleCreateCode = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Code: data.get("code"),
        Description: data.get("description"),
      };

      const response = await fetch("api/v1/MCCCode/CreateMCCCode", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setCodes([...codes, result])
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  const handleSelectCode = (event: SelectChangeEvent) => {
    let selectedCode = codes.find(x => x.id == event.target.value)

    setCode(selectedCode);
  };
  //------------

  return (
    <Item>
      <Box className="codePanel" gridColumn="span 3">
        <InputLabel id="demo-simple-select-label">MCC коды</InputLabel>
        <Select
          fullWidth
          label="Описание"
          onChange={handleSelectCode}
        >
          {
            codes?.map((code: any) => {
              return (
                <MenuItem key={code.id} value={code.id}>{code.code}</MenuItem>
              );
            })}
        </Select>
        <TextField
          label="Описание"
          fullWidth
          multiline
          value={code?.code ? code?.description || 'Описание отсутсвует' : ""}
          inputProps={{ readOnly: true, }}
          InputLabelProps={{ shrink: true }}
          margin="normal"
        />
        <Box
          className="createPanel"
          sx={{ mt: 1 }}
        >
          <Divider />
          <InputLabel>Создать MCC код</InputLabel>
          <Box
            component="form"
            onSubmit={handleCreateCode}
            sx={{ mt: 1 }}>
            <TextField
              name="code"
              autoComplete="code"
              label="MCC код"
              margin="normal"
              fullWidth
              required
            />
            <TextField
              name="description"
              autoComplete="description"
              label="Описание"
              margin="normal"
              fullWidth
            />
            <Button
              type="submit"
              variant="contained"
              fullWidth
              disabled={loadingState.Loading}>
              Создать
            </Button>
          </Box>
        </Box>
      </Box>
    </Item>
  );
};

export default CodePanel;

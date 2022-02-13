import * as React from "react";
import { useContext, useEffect, useState } from "react";
import { Box, Button, Divider, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import Item from "../../MuiExtensions/Item";
import wrapAPICall from "../../GlobalState/LoadingState/wrapAPICall";
import { LoadingContext } from "../../GlobalState/LoadingState/LoadingStore";

const StorePanel = (props: any) => {
  const [loadingState, setLoadingState]: any = useContext(LoadingContext);

  const [commercialNetwork, setCommercialNetwork] = useState<any>({});
  const [commercialNetworks, setCommercialNetworks] = useState<any[]>([]);

  const [stores, setStores] = useState<any[]>([]);

  useEffect(() => {
    wrapAPICall(loadCommercialNetworkData, setLoadingState);
  }, [])

  const loadCommercialNetworkData = async () => {
    const response = await fetch("api/v1/CommercialNetwork/GetAllCommercialNetworks", {
      method: "GET",
    });

    const result = await response.json();

    switch (response.status) {
      case 200:
        setCommercialNetworks(result);
        UpdateData((x: any) => x.id == commercialNetwork.id)
      case 400:
      default:
    }
  }

  const UpdateData = (commercialNetworkPredicate: any) => {
    let selectedCommercialNetwork = commercialNetworks.find(commercialNetworkPredicate)

    console.log("selectedCommercialNetwork");
    console.log(selectedCommercialNetwork);

    if (selectedCommercialNetwork) {
      setCommercialNetwork(selectedCommercialNetwork);
      setStores(selectedCommercialNetwork.stores)
    }
  };

  //--- Commercial network region ---
  const handleCreateCommercialNetwork = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Name: data.get("commercialnetworkname"),
      };

      const response = await fetch("api/v1/CommercialNetwork/CreateCommercialNetwork", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setCommercialNetworks([...commercialNetworks, result])
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  const handleSelectCommercialNetwork = (event: SelectChangeEvent) => {
    UpdateData((x: any) => x.id == event.target.value)
  };
  //------------

  //--- Store region ---
  const handleCreateStore = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        CommercialNetworkId: commercialNetwork.id,
        MCCCode: data.get("code"),
        Address: data.get("address"),
      };

      const response = await fetch("api/v1/Store/CreateStore", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setStores([...stores, result])
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  //------------

  //--- Helpers region ---

  const GenerateStoresInfo = (stores: any[]) => {
    console.log("stores gen")
    console.log(stores)

    return stores.map((s: any) => `${s.mccCode?.code} [${s.address || "Адрес не указан"}]`).join("\n");
  }

  //------------

  return (
    <Item>
      <Box
        sx={{
          display: 'grid',
          gap: 1,
          gridTemplateColumns: 'repeat(12, 1fr)',
        }}
      >
        <Box className="commercialNetworkPanel" gridColumn="span 6">
          <InputLabel id="demo-simple-select-label">Магазины</InputLabel>
          <Select
            value={commercialNetwork?.name}
            fullWidth
            label="Название магазина"
            onChange={handleSelectCommercialNetwork}
          >
            {
              commercialNetworks?.map((commercialNetwork: any) => {
                return (
                  <MenuItem value={commercialNetwork.id}>{commercialNetwork.name}</MenuItem>
                );
              })}
          </Select>
          <Box
            className="createPanel"
            sx={{ mt: 1 }}
          >
            <Divider />
            <InputLabel>Создать магазин</InputLabel>
            <Box
              component="form"
              onSubmit={handleCreateCommercialNetwork}
              sx={{ mt: 1 }}>
              <TextField
                name="commercialnetworkname"
                autoComplete="commercialnetworkname"
                label="Название магазина"
                margin="normal"
                fullWidth
                required
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

        <Box className="storePanel" gridColumn="span 6">
          <InputLabel>Торговые точки</InputLabel>
          <TextField
            name="conditions"
            autoComplete="conditions"
            label="Торговые точки"
            fullWidth
            multiline
            value={GenerateStoresInfo(stores)}
            inputProps={{ readOnly: true, }}
            InputLabelProps={{ shrink: true }}
            margin="normal"
          />
          <Box
            className="createPanel"
            sx={{ mt: 1 }}>
            <Divider />
            <InputLabel>Создать торговую точку</InputLabel>
            <Box
              component="form"
              onSubmit={handleCreateStore}
              sx={{ mt: 1 }}>
              <TextField
                name="code"
                label="MCC код"
                margin="normal"
                fullWidth
                required
              />
              <TextField
                name="address"
                label="Адрес торговой точки"
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
      </Box>
    </Item>
  );
};

export default StorePanel;

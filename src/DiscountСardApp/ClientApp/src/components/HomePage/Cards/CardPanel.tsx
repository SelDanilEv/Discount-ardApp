import * as React from "react";
import { useContext, useEffect, useState } from "react";
import { Box, Button, Divider, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from "@mui/material";
import Item from "../../MuiExtensions/Item";
import wrapAPICall from "../../GlobalState/LoadingState/wrapAPICall";
import { LoadingContext } from "../../GlobalState/LoadingState/LoadingStore";

const CardPanel = (props: any) => {
  const [loadingState, setLoadingState]: any = useContext(LoadingContext);

  const [bank, setBank] = useState<any>({});
  const [banks, setBanks] = useState<any[]>([]);

  const [card, setCard] = useState<any>({});
  const [cards, setCards] = useState<any[]>([]);

  useEffect(() => {
    wrapAPICall(loadBanksData, setLoadingState);
  }, [])

  const loadBanksData = async () => {
    const response = await fetch("api/v1/Bank/GetAllBanks", {
      method: "GET",
    });

    const result = await response.json();

    switch (response.status) {
      case 200:
        console.log("loadBanksData");
        console.log("result");
        console.log(result);
        console.log("bank1");
        console.log(bank);

        console.log("banks1");
        console.log(banks);
        setBanks(result);
        console.log("banks2");
        console.log(banks);

        UpdateData((x: any) => x.id == bank.id)

        console.log("bank2");
        console.log(bank);
      case 400:
      default:
    }
  }

  const UpdateData = (bankPredicate: any) => {

    let selectedBank = banks.find(bankPredicate)

    console.log("selectedBank");
    console.log(selectedBank);

    if (selectedBank) {
      setBank(selectedBank);
      setCards(selectedBank.discountCards)
    }
  };

  //--- Bank region ---
  const handleCreateBank = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Name: data.get("bankname"),
      };

      const response = await fetch("api/v1/Bank/CreateBank", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setBanks([...banks, result])
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  const handleSelectBank = (event: SelectChangeEvent) => {
    UpdateData((x: any) => x.id == event.target.value)
  };
  //------------

  //--- Card region ---
  const handleCreateCard = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Name: data.get("cardname"),
        Conditions: data.get("conditions"),
        BankId: bank.id,
      };

      const response = await fetch("api/v1/DiscountCard/CreateDiscountCard", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setCards([...cards, result])
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  const handleSelectCard = (event: SelectChangeEvent) => {
    let selectedCard = cards.find(x => x.id == event.target.value)

    setCard(selectedCard);
  };
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
        <Box className="bankPanel" gridColumn="span 3">
          <InputLabel id="demo-simple-select-label">Bank</InputLabel>
          <Select
            value={bank?.name}
            label="Bank"
            onChange={handleSelectBank}
          >
            {
              banks?.map((bank: any) => {
                return (
                  <MenuItem value={bank.id}>{bank.name}</MenuItem>
                );
              })}
          </Select>
          <Box
            component="form"
            onSubmit={handleCreateBank}
            sx={{ mt: 1 }}>
            <TextField
              name="bankname"
              autoComplete="bankname"
              label="Bank name"
              margin="normal"
              required
            />
            <Button
              type="submit"
              variant="contained"
              disabled={loadingState.Loading}>
              Create bank
            </Button>
          </Box>
        </Box>
        <Box className="cardPanel" gridColumn="span 3">
          <InputLabel>Discount card</InputLabel>
          <Select
            value={card?.name}
            label="Card"
            onChange={handleSelectCard}
          >
            {
              cards?.map((card: any) => {
                return (
                  <MenuItem value={card.id}>{card.name}</MenuItem>
                );
              })}
          </Select>
          <TextField
            name="conditions"
            autoComplete="conditions"
            value={card.conditions}
            inputProps={
              { readOnly: true, }
            }
            margin="normal"
          />
          <Divider />
          <InputLabel>Create card</InputLabel>
          <Box
            component="form"
            onSubmit={handleCreateCard}
            sx={{ mt: 1 }}>
            <TextField
              name="cardname"
              autoComplete="cardname"
              label="Card name"
              margin="normal"
              required
            />
            <TextField
              name="conditions"
              autoComplete="conditions"
              label="Notes"
              margin="normal"
            />
            <Button
              type="submit"
              variant="contained"
              disabled={loadingState.Loading}>
              Create card
            </Button>
          </Box>
        </Box>
      </Box>
    </Item>
  );
};

export default CardPanel;

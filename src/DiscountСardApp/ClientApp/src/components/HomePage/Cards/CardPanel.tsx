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

  const [category, setCategory] = useState<any>({});
  const [categories, setCategories] = useState<any[]>([]);

  const [codes, setCodes] = useState<string>("");

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
        setBanks(result);
        UpdateData((x: any) => x.id == bank.id)
      case 400:
      default:
    }
  }

  const UpdateData = (bankPredicate: any) => {
    setBank({});
    setCard({});
    setCategory({});
    setCategories([]);
    setCodes("");

    let selectedBank = banks.find(bankPredicate)

    console.log("selectedBank");
    console.log(selectedBank);

    if (selectedBank) {
      setBank(selectedBank);
      setCards(selectedBank.discountCards)
    };
  }

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

    console.log("selectedCard")
    console.log(selectedCard)

    setCard(selectedCard);
    setCategories(selectedCard.categories);
  };
  //------------


  //--- Category region ---
  const handleCreateCategory = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Name: data.get("categoryname"),
        DiscountCardId: card.id,
      };

      const response = await fetch("api/v1/Category/CreateCategory", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      console.log("category result")
      console.log(result)

      switch (response.status) {
        case 200:
          setCategories([...categories, result])
          console.log(categories)
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  const handleSelectCategory = (event: SelectChangeEvent) => {
    let selectedCategory = categories.find(x => x.id == event.target.value)

    console.log("selectedCategory");
    console.log(selectedCategory);

    setCategory(selectedCategory);
    setCodes(FormatCodes(selectedCategory.mccCodes));
  };
  //------------


  //--- Codes region ---
  const handleReplaceCodes = async (event: React.FormEvent<HTMLFormElement>) => {
    wrapAPICall(async () => {
      event.preventDefault();
      const data = new FormData(event.currentTarget);

      const requestData = {
        Codes: data.get("codes")?.toString(),
        CategoryId: category.id,
      };

      const response = await fetch("api/v1/Category/ReplaceCodes", {
        method: "POST",
        body: JSON.stringify(requestData),
        headers: {
          "Content-Type": "application/json",
        },
      });

      const result = await response.json();

      switch (response.status) {
        case 200:
          setCodes(result.codes)
          break;
        case 400:
        default:
      }
    }, setLoadingState);
  };

  //------------

  //--- Helpers region ---

  const FormatCodes = (codeItems: any[]) => {
    if (!codeItems) return "";

    return codeItems.map((c: any) => c.code).join(", ");
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
        <Box className="bankPanel" gridColumn="span 3">
          <InputLabel id="demo-simple-select-label">Банки</InputLabel>
          <Select
            value={bank?.name}
            fullWidth
            label="Название банка"
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
            className="createPanel"
            sx={{ mt: 1 }}
          >
            <Divider />
            <InputLabel>Создать банк</InputLabel>
            <Box
              component="form"
              onSubmit={handleCreateBank}
              sx={{ mt: 1 }}>
              <TextField
                name="bankname"
                autoComplete="bankname"
                label="Название банка"
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

        <Box className="cardPanel" gridColumn="span 3">
          <InputLabel>Дисконтные карты</InputLabel>
          <Select
            value={card?.name}
            label="Карта"
            fullWidth
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
            label="Примечания (условия)"
            fullWidth
            multiline
            value={card?.conditions || ""}
            inputProps={{ readOnly: true, }}
            InputLabelProps={{ shrink: true }}
            margin="normal"
          />
          <Box
            className="createPanel"
            sx={{ mt: 1 }}>
            <Divider />
            <InputLabel>Создать карту</InputLabel>
            <Box
              component="form"
              onSubmit={handleCreateCard}
              sx={{ mt: 1 }}>
              <TextField
                name="cardname"
                autoComplete="cardname"
                label="Название карты"
                margin="normal"
                fullWidth
                required
              />
              <TextField
                name="conditions"
                autoComplete="conditions"
                label="Примечания (условия)"
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

        <Box className="categoryPanel" gridColumn="span 3">
          <InputLabel id="demo-simple-select-label">Категории</InputLabel>
          <Select
            value={category?.name}
            fullWidth
            label="Название категории"
            onChange={handleSelectCategory}
          >
            {
              categories?.map((category: any) => {
                return (
                  <MenuItem value={category.id}>{category.name}</MenuItem>
                );
              })}
          </Select>
          <Box
            className="createPanel"
            sx={{ mt: 1 }}
          >
            <Divider />
            <InputLabel>Создать категорию</InputLabel>
            <Box
              component="form"
              onSubmit={handleCreateCategory}
              sx={{ mt: 1 }}>
              <TextField
                name="categoryname"
                autoComplete="categoryname"
                label="Название категории"
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

        <Box className="categoryCodesPanel" gridColumn="span 3">
          <InputLabel>MCC коды</InputLabel>
          <TextField
            name="codes"
            label="Коды"
            fullWidth
            multiline
            value={codes}
            inputProps={{ readOnly: true, }}
            InputLabelProps={{ shrink: true }}
            margin="normal"
          />
          <Box
            className="createPanel"
            sx={{ mt: 1 }}>
            <Divider />
            <InputLabel>Заменить коды</InputLabel>
            <Box
              component="form"
              onSubmit={handleReplaceCodes}
              sx={{ mt: 1 }}>
              <TextField
                name="codes"
                label="Новые коды"
                margin="normal"
                multiline
                fullWidth
                required
              />
              <Button
                type="submit"
                variant="contained"
                fullWidth
                disabled={loadingState.Loading}>
                Заменить
              </Button>
            </Box>
          </Box>
        </Box>
      </Box>
    </Item>
  );
};

export default CardPanel;

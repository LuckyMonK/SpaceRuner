using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernController : TavernElement
{
    public void Start()
    {
        GoDefault();
        FillPlaces();
    }

    private void FillPlaces() {
        app.TavernModel.FillData();
        app.TavernView.CreateCharactersView();
    }

    public void ComeClose(int index) {
        app.TavernModel.curentIndex = index;
        app.TavernView.ComeClose();
    }

    public void GoDefault() {
        app.TavernView.SetDefault();
    }

    public void TryToBuy() {
        bool result = app.TavernModel.playerInformation.playerData.money >= app.TavernModel.characters[app.TavernModel.curentIndex].cost;

        app.TavernView.BuyEffect(result);

        if (result) {
            app.TavernModel.playerInformation.playerData.character = app.TavernModel.characters[app.TavernModel.curentIndex];
            app.TavernModel.playerInformation.playerData.money -= app.TavernModel.characters[app.TavernModel.curentIndex].cost;
        }
    }
}

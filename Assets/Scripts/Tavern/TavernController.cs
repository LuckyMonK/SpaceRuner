using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernController : TavernElement
{
    public void Start()
    {
        app.TavernView.FirstCameraMove();
        FillPlaces();
    }

    private void FillPlaces() {
        app.TavernModel.FillData();
        app.TavernView.CreateCharactersView();
    }
}

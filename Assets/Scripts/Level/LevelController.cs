using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : LevelElement
{
    private void Start()
    {
        app.LevelView.BuildLevel(app.LevelModel.GetActualLevelData());
        app.LevelView.CreateEnemies(app.LevelModel.GetActualLevelData());
    }
}

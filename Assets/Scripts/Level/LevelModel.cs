using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : LevelElement
{
    [SerializeField] private LevelsData levelData;
    [SerializeField] private float dz = 0.3f;
    private LevelData currentLevelData;
    public int LevelScale = 2;
    public LevelData GetActualLevelData() { 
        return levelData.levels[PlayerPrefs.GetInt("Level") % levelData.levels.Count];
    }
}

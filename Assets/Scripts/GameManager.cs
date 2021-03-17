using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instantiate;

    [SerializeField] private GameData gameData;

    [SerializeField] private LevelGenerator levelGenerator;
    private void Awake()
    {
        if (!Instantiate) {
            Instantiate = this;
        }

        Initialise();

    }

    private void Initialise() {
        gameData = new GameData(PlayerPrefs.GetInt("Level"), 0f);

        levelGenerator.GenerateLevel(gameData.level);
    }
}

[System.Serializable]
public class GameData {
    public int level;
    public float distance;

    public GameData(int level, float distance)
    {
        this.level = level;
        this.distance = distance;
    }
}

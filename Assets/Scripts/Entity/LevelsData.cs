using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelsData", order = 1)]
public class LevelsData : ScriptableObject
{
    public List<LevelData> levels;
}

[System.Serializable]
public class LevelData {
    public AnimationCurve[] levelCurves;
    public float traceLength;

    public GameObject[] segments;
    public GameObject[] enemies;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : LevelElement
{
    [SerializeField] private Transform levelRoot;
    public void BuildLevel(LevelData currentLevelData)
    {
        float dt = 1 / currentLevelData.traceLength;
        for (int i = 0; i < currentLevelData.traceLength; i++)
        {
            var go = Instantiate(currentLevelData.segments[Random.Range(0, currentLevelData.segments.Length)], levelRoot);
            Vector2 curvePos = new Vector2(currentLevelData.levelCurves[0].Evaluate(dt * i), currentLevelData.levelCurves[1].Evaluate(dt * i));
            go.transform.position = new Vector3(curvePos.x, curvePos.y, i * app.LevelModel.LevelScale);

            if (i < currentLevelData.traceLength - 1) {
                curvePos = new Vector2(currentLevelData.levelCurves[0].Evaluate(dt * (i + 1)), 
                    currentLevelData.levelCurves[1].Evaluate(dt * (i + 1)));
                go.transform.LookAt(new Vector3(curvePos.x, curvePos.y, (i + 1) * app.LevelModel.LevelScale));
            }
        }
    }
}

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

    public void CreateEnemies(LevelData currentLevelData) {
        int numOfEnemies = Random.Range((int)app.LevelModel.levelBounds.x, (int)app.LevelModel.levelBounds.y);
        float R = 0.5f;
        float progress = 0f;
        float angle;
        for (int i = 1; i <= numOfEnemies; i++) {
            float temp = Random.Range(0.0f, progress + i / (float)numOfEnemies);
            angle = Random.Range(0f, 360f);
            progress = (i - 1) / numOfEnemies + temp;
            Vector3 curvePos = new Vector3(currentLevelData.levelCurves[0].Evaluate(progress), 
                currentLevelData.levelCurves[1].Evaluate(progress),
                currentLevelData.traceLength * app.LevelModel.LevelScale * progress) 
                + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * R;
            
            Instantiate(currentLevelData.enemies[Random.Range(0, currentLevelData.enemies.Length)], curvePos, Quaternion.identity);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelsData levelData;
    [SerializeField] private float dz = 0.3f;
    private LevelData currentLevelData;

    [SerializeField] private Transform levelRoot;
    public void GenerateLevel(int level) {
        currentLevelData = levelData.levels[level % levelData.levels.Count];
        float dt = 1 / currentLevelData.traceLength;
        for (int i = 0; i < currentLevelData.traceLength; i++) {
            var go = Instantiate(currentLevelData.segments[Random.Range(0, currentLevelData.segments.Length)], levelRoot);
            Vector2 curvePos = new Vector2(currentLevelData.levelCurves[0].Evaluate(dt * i), currentLevelData.levelCurves[1].Evaluate(dt * i));
            go.transform.position = new Vector3(curvePos.x, curvePos.y, i * 15);
            go.transform.eulerAngles = new Vector3(CurveHelper.Derivative(currentLevelData.levelCurves[0], currentLevelData.levelCurves[0].Evaluate(dt * i)),
                CurveHelper.Derivative(currentLevelData.levelCurves[1], currentLevelData.levelCurves[1].Evaluate(dt * i)), 
                0);
        }
    }


    
}

public static class CurveHelper { 
public static float Derivative(this AnimationCurve self, float time)
    {
        if (self == null) return 0.0f;
        for (int i = 0; i < self.length - 1; i++)
        {
            if (time < self[i].time) continue;
            if (time > self[i + 1].time) continue;
            return Derivative(self[i], self[i + 1], (time - self[i].time) / (self[i + 1].time - self[i].time));
        }
        return 0.0f;
    }

    private static float Derivative(Keyframe from, Keyframe to, float lerp)
    {
        float dt = to.time - from.time;

        float m0 = from.outTangent * dt;
        float m1 = to.inTangent * dt;

        float lerp2 = lerp * lerp;

        float a = 6.0f * lerp2 - 6.0f * lerp;
        float b = 3.0f * lerp2 - 4.0f * lerp + 1.0f;
        float c = 3.0f * lerp2 - 2.0f * lerp;
        float d = -a;

        return a * from.value + b * m0 + c * m1 + d * to.value;
    }
}

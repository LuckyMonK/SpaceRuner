using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : PlayerElement
{
    [SerializeField] private Transform player;
    public void StartMovement() {
        app.PlayerModel.SetState(PlayerState.Fly);
        app.PlayerView.SetAnimation(app.PlayerModel.GetState());
        StartCoroutine(Movement());
    }

    private IEnumerator Movement() {
        float time = 0f;
        Vector3 nextPos = Vector3.zero;
        LevelModel levelModel = FindObjectOfType<LevelApplication>().LevelModel;
        LevelData currentLevelData = levelModel.GetActualLevelData();
        app.PlayerModel.speed = 1f;

        float dt = 1 / currentLevelData.traceLength;
        for (int i = 0; i < currentLevelData.traceLength; i++)
        {
            Vector2 curvePos = new Vector2(currentLevelData.levelCurves[0].Evaluate(dt * i), currentLevelData.levelCurves[1].Evaluate(dt * i));
            nextPos = new Vector3(curvePos.x, curvePos.y, i * levelModel.LevelScale);
            MoveTo(nextPos, 1f);
            yield return new WaitForSeconds(1f);
        }
    }

    void MoveTo(Vector3 target, float duration)
    {
        player.transform.DOMove(target, duration).SetEase(Ease.Linear);
        player.transform.DOLookAt(target, duration).SetEase(Ease.Linear);
        //cor1 = StartCoroutine(AnimateMove(player.position, target, duration));

    }

    
    //IEnumerator AnimateMove(Vector3 origin, Vector3 target, float duration)
    //{
    //    float journey = 0f;
    //    while (journey <= duration)
    //    {
    //        journey = journey + Time.deltaTime;
    //        float percent = Mathf.Clamp01(journey / duration);

    //        player.position = Vector3.Lerp(origin, target, percent);
    //        player.rotation = Quaternion.Lerp(player.rotation, Quaternion.LookRotation(target), journey / duration);
    //        yield return null;
    //    }
    //}
}

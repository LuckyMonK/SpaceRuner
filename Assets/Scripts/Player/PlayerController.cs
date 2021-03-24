using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : PlayerElement
{
    //часть игрока, которая летит по основной траектории
    [SerializeField] private Transform player;
    private delegate void ProcessPlayerInput();
    private ProcessPlayerInput ProcessMovement;

    public void StartMovement() {
        app.PlayerModel.SetState(PlayerState.Fly);
        ProcessMovement += FlyingMovement;
        app.PlayerView.SetAnimation(app.PlayerModel.GetState());
        StartCoroutine(Movement());
        app.PlayerView.UpdateBars(app.PlayerModel.hpLimit, app.PlayerModel.chargeLimit);
    }

    //private IEnumerator ValuesUpdate() {
    //    float timer = 0f;

    //    while (true) {
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //}
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
            MoveTo(nextPos, app.PlayerModel.speed);
            yield return new WaitForSeconds(app.PlayerModel.speed);
        }
    }

    void MoveTo(Vector3 target, float duration)
    {
        player.transform.DOMove(target, duration).SetEase(Ease.Linear);
        player.transform.DOLookAt(target, duration).SetEase(Ease.Flash);
    }

    private void Update()
    {
        if (app.PlayerModel.GetState() is PlayerState.Fly) {
            ProcessMovement();
        }
    }

    private void FlyingMovement() {
        if (app.PlayerView.joystick.ScaledValue.magnitude > 0.1f)
        {
            Vector2 movement = app.PlayerView.joystick.ScaledValue;
            app.PlayerView.playerRoot.localPosition = Vector3.MoveTowards(app.PlayerView.playerRoot.localPosition, movement * app.PlayerModel.R, Time.deltaTime / 3f);
        }

    }

    public void Damage(int value) {
        app.PlayerView.UpdateBars(app.PlayerModel._hp - value, app.PlayerModel._weaponCharge);
    }
}

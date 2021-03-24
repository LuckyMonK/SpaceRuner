using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { 
    Start,
    Fly,
    Win,
    Lose
}
public class PlayerModel : PlayerElement
{
    //скорость полета по тректории
    public float speed = 0f;
    //отклонение игрока от основной оси полета
    public float R = 0.6f;

    
    public int hpLimit = 100;
    public float chargeLimit = 100f;

    public int _hp;
    public float _weaponCharge;

    [SerializeField] private float distance = 0f;
    [SerializeField] private PlayerState state;
    public AnimationCurve speedCurve;

    public bool isFinish = false;

    public void SetState(PlayerState state) {
        this.state = state;
    }

    public PlayerState GetState() {
        return state;
    }

    private void UpdateHpLimit( int newHp) {
        hpLimit = newHp;
    }
}

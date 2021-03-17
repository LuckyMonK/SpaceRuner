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
    public float speed = 0f;
    [SerializeField] private float distance = 0f;
    [SerializeField] private PlayerState state;

    public void SetState(PlayerState state) {
        this.state = state;
    }

    public PlayerState GetState() {
        return state;
    }
}

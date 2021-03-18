using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class PlayerView : PlayerElement
{
    [SerializeField] private Animator anim;
    public Transform playerRoot;
    private PlayerAnimationController animationController;
    public LeanJoystick joystick;

    private void Start()
    {
        Initialize();
    }

    private void Initialize() {
        animationController = new PlayerAnimationController(anim);
    }

    public void SetAnimation(PlayerState state) {
        switch (state) {
            case PlayerState.Fly:
                animationController.StartFly();
                break;
        }
    }
}

public class PlayerAnimationController {
    private Animator anim;

    public PlayerAnimationController(Animator anim)
    {
        this.anim = anim;
    }

    public void StartFly() {
        anim.SetTrigger("Fly");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : PlayerElement
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerRoot;
    private PlayerAnimationController animationController;

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

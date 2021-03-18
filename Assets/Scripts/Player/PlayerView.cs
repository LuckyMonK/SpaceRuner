using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;
using DG.Tweening;

public class PlayerView : PlayerElement
{
    [SerializeField] private Animator anim;
    public Transform playerRoot;
    private PlayerAnimationController animationController;
    public LeanJoystick joystick;

    [SerializeField] private RadialSlider hpSlider;
    [SerializeField] private RadialSlider chargeSlider;

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
    public void UpdateBars(int hpUpdate, float chargeUpdate)
    {
        DOVirtual.Float(app.PlayerModel._hp, hpUpdate, 1f, (_value) =>
        {
            hpSlider.UpdateSliderValue(_value, app.PlayerModel.hpLimit);
        });

        DOVirtual.Float(app.PlayerModel._weaponCharge, chargeUpdate, 1f, (_value) =>
        {
            chargeSlider.UpdateSliderValue(_value, app.PlayerModel.hpLimit);
        });

        app.PlayerModel._hp = hpUpdate;
        app.PlayerModel._weaponCharge = chargeUpdate;
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

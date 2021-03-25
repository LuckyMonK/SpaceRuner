using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRangeType {
    Melee,
    Gun
}

public enum AtackState { 
    Default,
    Atack
}
public class WeaponController : WeaponElement
{

    private Coroutine shootingCoroutine;
    [SerializeField] private Lean.Gui.LeanJoystick joystick;
    [SerializeField] private AtackState state;
    [SerializeField] private GameApplication gameApplication;
    public void InitializeWeapon()
    {
        app.WeaponModel.InitializeWeaponData();
        app.WeaponView.SetWeaponView(app.WeaponModel.weapon.view);
        //shootingCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        app.WeaponView.SetShootArmsWeight(1f, 0.8f);
        float timer = app.WeaponModel.weapon.shootingCooldown;
        //первый выстрел
        if (app.WeaponModel.shootingTargets.Count > 0)
        {
            Shoot();
        }

        while (true)
        {
            //если список целей пуст
            if (app.WeaponModel.shootingTargets.Count == 0)
            {
                while (app.WeaponModel.shootingTargets.Count == 0)
                {
                    yield return null;
                }
                timer = app.WeaponModel.weapon.shootingCooldown;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Shoot();
                timer = app.WeaponModel.weapon.shootingCooldown;
            }
            yield return null;
        }
    }

    private void Shoot() {
        //app.WeaponView.ShootAnimation();
    }

    private void Update()
    {
        if (gameApplication.PlayerModel.GetState() != PlayerState.Fly) {
            return;
        }
        if (joystick.ScaledValue.magnitude < 0.1 && state == AtackState.Default 
            && app.WeaponModel.shootingTargets.Count > 0)
        {
            state = AtackState.Atack;
            shootingCoroutine = StartCoroutine(Shooting());
        }
        else if ((joystick.ScaledValue.magnitude > 0.1 || app.WeaponModel.shootingTargets.Count == 0) 
            && state == AtackState.Atack) {
            StopCoroutine(shootingCoroutine);
            state = AtackState.Default;
            app.WeaponView.SetShootArmsWeight(0f, 0.8f);
        }
    }

}
[System.Serializable]
public class Weapon {
    public WeaponType view;
    public float damage = 1f;
    public float range = 10f;
    public float shootingCooldown = 1f;
}
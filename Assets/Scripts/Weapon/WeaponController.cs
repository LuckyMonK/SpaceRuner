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
    [SerializeField] private ProjectileController projectileController;
    public void InitializeWeapon()
    {
        app.WeaponModel.InitializeWeaponData();
        app.WeaponView.SetWeaponView(app.WeaponModel.weapon.WeaponRangeType);
        //shootingCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        app.WeaponView.SetShootArmsWeight(1f, 0.8f, 1f / app.WeaponModel.weapon.ShootingCooldown);
        float timer = app.WeaponModel.weapon.ShootingCooldown;
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
                timer = app.WeaponModel.weapon.ShootingCooldown;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Shoot();
                timer = app.WeaponModel.weapon.ShootingCooldown;
            }
            yield return null;
        }
    }

    public void Shoot() {
        projectileController.SetProjectile(app.WeaponModel.weapon.Projectile, 
            app.WeaponModel.shootingTargets, app.WeaponModel.weapon);
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
            app.WeaponView.SetShootArmsWeight(0f, 0.8f, 1f);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRangeType {
    Melee,
    Gun
}
public class WeaponController : WeaponElement
{

    private Coroutine shootingCoroutine;

    public void InitializeWeapon()
    {
        app.WeaponModel.InitializeWeaponData();
        app.WeaponView.SetWeaponView(app.WeaponModel.weapon.view);
        shootingCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
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
        app.WeaponView.ShootAnimation();
    }

}
[System.Serializable]
public class Weapon {
    public WeaponType view;
    public float damage = 1f;
    public float range = 10f;
    public float shootingCooldown = 1f;
}
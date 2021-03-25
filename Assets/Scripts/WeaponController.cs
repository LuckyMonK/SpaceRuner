using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRangeType {
    Melee,
    Gun
}

public enum WeaponView { 
    Riffle,

}
public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    [SerializeField] private Transform[] shootingTargets;

    private Coroutine shootingCoroutine;

    [SerializeField] private GameObject[] weaponViewList;
    public void InitializeWeapon() {
        weapon = PlayerInformation.Instantiate.playerData.weapon;
        foreach (var weapon in weaponViewList) {
            weapon.SetActive(false);
        }
        weaponViewList[(int)weapon.view].SetActive(true);
        shootingCoroutine = StartCoroutine(Shooting());
    }

    private IEnumerator Shooting() {
        float timer = weapon.shootingCooldown;
        //первый выстрел
        if (shootingTargets.Length > 0) {
            Shoot();
        }

        while (true) {
            //если список целей пуст
            if (shootingTargets.Length == 0) {
                while (shootingTargets.Length == 0)
                {
                    yield return null;
                }
                timer = weapon.shootingCooldown;
            }
            timer -= Time.deltaTime;
            if (timer <= 0) {
                Shoot();
                timer = weapon.shootingCooldown;
            }
            yield return null;
        }
    }

    private void Shoot() { 
    
    }

}
[System.Serializable]
public class Weapon {
    public WeaponView view;
    public float damage = 1f;
    public float range = 10f;
    public float shootingCooldown = 1f;
}
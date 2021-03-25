using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : WeaponElement
{
    public Weapon weapon;

    public List<Transform> shootingTargets;

    public void InitializeWeaponData()
    {
        weapon = PlayerInformation.Instantiate.playerData.weapon;
        //foreach (var weapon in weaponViewList)
        //{
        //    weapon.SetActive(false);
        //}
        //weaponViewList[(int)weapon.view].SetActive(true);
        //shootingCoroutine = StartCoroutine(Shooting());
    }
}

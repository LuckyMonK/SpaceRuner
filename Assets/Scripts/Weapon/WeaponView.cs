using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    Riffle,
    Sword
}
public class WeaponView : WeaponElement
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] views;

    public void SetWeaponView(WeaponType type) {
        views[(int)type].SetActive(true);
    }
    public void ShootAnimation() { 
        
    }
}

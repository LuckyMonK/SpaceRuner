using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    public void SetShootArmsWeight(float endWeight, float time, float speed) {
        anim.speed = speed;
        anim.SetTrigger("ArmIteraction");
        //anim.SetLayerWeight(1, endWeight);
        DOVirtual.Float(anim.GetLayerWeight(1), endWeight, time, (_value) =>
        {
            anim.SetLayerWeight(1, _value);
        });
    }
}

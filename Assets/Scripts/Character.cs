using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Character
{
    public string name;
    public float forwardSpeed;
    public float evasionSpeed;
    public float HP;
    public float energy;
    public GameObject viewPrefab;
    public Weapon weapon;
}

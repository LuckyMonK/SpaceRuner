using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponsData", menuName = "ScriptableObjects/WeaponsData", order = 2)]
public class WeaponsData : ScriptableObject
{
    public List<Weapon> weapons;
}

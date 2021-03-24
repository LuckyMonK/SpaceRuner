using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRangeType {
    Melee,
    Gun
}

public enum WeaponView { 
    
}
public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponViews;

    public void InitializeWeapon() { 
        
    }
}

public class Weapon {
    public WeaponView viewNimber;
}
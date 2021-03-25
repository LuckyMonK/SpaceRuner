using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponElement : MonoBehaviour {
    public WeaponApplication app;
}
public class WeaponApplication : MonoBehaviour
{
    public WeaponModel WeaponModel;
    public WeaponController WeaponController;
    public WeaponView WeaponView;
}

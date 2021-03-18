using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;
    public int GetDamageValue() {
        return damageValue;
    }
}

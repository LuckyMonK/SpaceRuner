using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagablePlayer : MonoBehaviour
{
    [SerializeField] private GameController controller;

    private void OnCollisionEnter(Collision collision)
    {
        var go = collision.gameObject.GetComponent<Enemy>();
        if (go) {
            controller.Damage(go.GetDamageValue());
        }
    }
}

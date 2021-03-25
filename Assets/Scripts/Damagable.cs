using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float HP = 100;

    public void Damage(float dmg) {
        HP -= dmg;
        if (HP < 0) {
            DestroyCharacterFromGame();
        }
    }

    private void DestroyCharacterFromGame()
    {
        FindObjectOfType<WeaponModel>().shootingTargets.Remove(transform);
        Destroy(gameObject);
    }
    //[SerializeField] private GameController controller;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    var go = collision.gameObject.GetComponent<Enemy>();
    //    if (go) {
    //        controller.Damage(go.GetDamageValue());
    //    }
    //}
}

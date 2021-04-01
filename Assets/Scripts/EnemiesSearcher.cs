using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemiesSearcher : MonoBehaviour
{
    [SerializeField] private WeaponModel WeaponModel;
    [SerializeField] private BoxCollider collider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy")) {
            WeaponModel.shootingTargets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (WeaponModel.shootingTargets.Any(item => item.transform == other.transform)) {
            WeaponModel.shootingTargets.Remove(other.transform);
        }
    }
}

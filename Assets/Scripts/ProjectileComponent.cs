using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public Projectile projectileInformation;
    private void OnTriggerEnter(Collider other)
    {
        var dmgble = other.GetComponent<Damagable>();
        if (dmgble
            && !other.tag.Equals(projectileInformation.projectileSource.ToString())) {
            dmgble.Damage(projectileInformation.Damage);
            Destroy(gameObject);
        }
    }
}

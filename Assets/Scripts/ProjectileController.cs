using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    [SerializeField] private List<Transform> targets;
    public void Shoot() {
        targets = targets.Where(item => item != null).ToList();
        if (targets.Count > 0) { 
            Rigidbody instantiatedProjectile = Instantiate(projectile.ProjectileComponent.gameObject,
                transform.position, 
                transform.rotation).GetComponent<Rigidbody>();
            ProjectileComponent proj = instantiatedProjectile.GetComponent<ProjectileComponent>();
            proj.projectileInformation = projectile;
            instantiatedProjectile.velocity = (targets[0].position - transform.position).normalized  * projectile.Speed;
            instantiatedProjectile.rotation = Quaternion.LookRotation((targets[0].position - transform.position).normalized);
        }
        
    }

    public void SetProjectile(Projectile projectile, List<Transform> targets, Weapon weaponInfo) {
        this.projectile = projectile;
        this.targets = targets;

        this.projectile.Damage += weaponInfo.Damage;
    } 
}
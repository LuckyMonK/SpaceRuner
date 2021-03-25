using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel : WeaponElement
{
    public Weapon weapon;

    public List<Transform> shootingTargets;

    public void InitializeWeaponData()
    {
        weapon = PlayerInformation.Instantiate.playerData.weapon;
    }
}
public enum ProjectileSourceType
{
    Player, 
    Enemy
}

[System.Serializable]
public class Weapon
{
    public WeaponType View;
    public float Damage = 1f;
    public float Range = 10f;
    public float ShootingCooldown = 1f;
    public Projectile Projectile;
}

[System.Serializable]
public class Projectile
{
    public ProjectileSourceType projectileSource;
    public float Speed;
    public ProjectileComponent ProjectileComponent;
    public float Damage;

    public Projectile(float speed, ProjectileComponent prefab, float damage)
    {
        this.Speed = speed;
        this.ProjectileComponent = prefab;
        this.Damage = damage;
    }
}

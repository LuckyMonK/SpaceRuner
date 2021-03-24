using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum ShooterState { 
    Passive,
    Active
}
public class EnemyShooter : Enemy
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootingCooldown = 1f;
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private float activationDistanse = 10f;
    [SerializeField] private ShooterState state;
    [SerializeField] private Transform projectileSource;
    private float distanse = 0;
    private Transform player;
    private Coroutine work;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanse = (transform.position - player.position).magnitude;

        if (distanse <= activationDistanse && state == ShooterState.Passive) {
            state = ShooterState.Active;
            work = StartCoroutine(Work());
        }

        if (state == ShooterState.Active && transform.position.z < player.transform.position.z) {
            state = ShooterState.Passive;
            StopCoroutine(work);
        }
    }

    private IEnumerator Work() {
        var cooldown = new WaitForSeconds(shootingCooldown);
        Vector3 shootingTarget;
        while (true) {
            shootingTarget = player.transform.position;
            var projectile = Instantiate(projectilePrefab, projectileSource.position, Quaternion.LookRotation(shootingTarget));
            projectile.transform.DOMove(shootingTarget, (projectileSource.position - shootingTarget).magnitude / projectileSpeed);
            yield return cooldown;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damageValue = 10;
    [SerializeField] private bool isDestroyOnContact = false;
    public int GetDamageValue() {
        return damageValue;
    }

    private void Start()
    {
        GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyOnContact) {
            Destroy(gameObject);
        }
    }
}

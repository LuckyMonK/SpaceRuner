using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRangeDestroyer : MonoBehaviour
{
    private Transform player;
    private float distance;
    [SerializeField] private float destroyRadius = 30f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.position).magnitude > destroyRadius) {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernDanceCharacter : MonoBehaviour
{
    [SerializeField] private Animator anim;
    void Start()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
        anim.SetInteger("state", Random.Range(0, 100) % 3);
        anim.SetTrigger("dance");
        
    }

}

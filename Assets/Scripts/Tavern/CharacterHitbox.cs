using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitbox : MonoBehaviour
{
    [SerializeField] private TavernApplication app;
    [SerializeField] private int index = 0;

    public static bool block = false;
    private void Start()
    {
        app = FindObjectOfType<TavernApplication>();
    }
    private void OnMouseDown()
    {
        if (!block) {
            block = true;
            app.TavernController.ComeClose(index);
        }
    }
}

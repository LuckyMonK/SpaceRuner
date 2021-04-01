using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TavernUIController : MonoBehaviour
{
    [SerializeField] private Button backBtn;
    void Start()
    {
        backBtn.onClick.AddListener(() => {
            FindObjectOfType<SceneManager>().LoadScene(Scene.CoreGame);
        });
    }
}

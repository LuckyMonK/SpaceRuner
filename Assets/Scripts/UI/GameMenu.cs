using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMenu : MonoBehaviour
{
    [SerializeField] private Button tavernBtn;
    [SerializeField] private Button startGameBtn;

    [SerializeField] private GameController GameController;
    [SerializeField] private GameUIController GameUIController;

    private void Start()
    {
        startGameBtn.onClick.AddListener( () => {
            GameController.StartMovement();
            GameUIController.OpenGamePlayPanel();
        });

        tavernBtn.onClick.AddListener(() => {
            FindObjectOfType<SceneManager>().LoadScene(Scene.Tavern);
        });
    }
}

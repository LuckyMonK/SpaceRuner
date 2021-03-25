using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject gameMenuPanel;
    [SerializeField] private GameObject gamePlayPanel;

    public void OpenGameMenuPanel() {
        DisableAll();
        gameMenuPanel.SetActive(true);
    }

    public void OpenGamePlayPanel()
    {
        DisableAll();
        gamePlayPanel.SetActive(true);
    }
    private void DisableAll() {
        gameMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }
}

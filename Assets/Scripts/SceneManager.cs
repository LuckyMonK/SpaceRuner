using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public enum Scene { 
    CoreGame,
    Tavern
}
public class SceneManager : MonoBehaviour
{
    public static SceneManager Instantiate;

    [SerializeField] private CanvasGroup fade;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Slider progress;
    void Start()
    {
        if (!Instantiate)
        {
            Instantiate = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void LoadScene(int i) {
        StartCoroutine(Loading(i));
    }

    private IEnumerator Loading(int i) {
        canvas.SetActive(true);
        DOVirtual.Float(0, 1, 0.3f, (_value) => {
            fade.alpha = _value;
        });
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(i);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }

        DOVirtual.Float(1, 0, 0.3f, (_value) => {
            fade.alpha = _value;
        }).OnComplete( () => {
            canvas.SetActive(false) ;
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TavernView : TavernElement
{
    [SerializeField] private Transform firstCameraPos;

    [SerializeField] public Transform[] playersSpawnPlaces;
    [SerializeField] private RuntimeAnimatorController PlayerAnimationController;
    [SerializeField] private List<GameObject> playerViews;

    [SerializeField] private Transform[] charactersCameraPos;

    [SerializeField] private TavernUIController uiController;

    private Tween movingTween;
    private Tween rotationTween;

    private void Start()
    {
        uiController.leftBtn.onClick.AddListener(() => {
            MoveLeft();
        });

        uiController.rightBtn.onClick.AddListener(() => {
            MoveRight();
        });

        uiController.buyBtn.onClick.AddListener(() => {
            app.TavernController.TryToBuy();
        });

        uiController.backToMainPanelBtn.onClick.AddListener(() => { SetDefault(); });
    }
    public void SetDefault() {
        KillCameraMoving();
        movingTween = Camera.main.transform.DOMove(firstCameraPos.position, 2f);
        rotationTween = Camera.main.transform.DORotate(firstCameraPos.eulerAngles, 1f);
        uiController.OpenStartMenuPanel();
        CharacterHitbox.block = false;
    }

    public void CreateCharactersView() {
        for (int i = 0; i < playersSpawnPlaces.Length; i++) {
            playerViews.Add(Instantiate(app.TavernModel.characters[i].viewPrefab, 
                playersSpawnPlaces[i].position, playersSpawnPlaces[i].rotation));
            //app.TavernModel.characters[i].viewPrefab = view;
            playerViews[i].transform.parent = playersSpawnPlaces[i];
            var tempAnim = playerViews[i].GetComponent<Animator>();
            tempAnim.runtimeAnimatorController = PlayerAnimationController;
            tempAnim.applyRootMotion = true;
            tempAnim.SetInteger("state", Random.Range(0, 2));
            tempAnim.SetTrigger("sitting");
        }
    }

    public void ComeClose() {
        KillCameraMoving();
        movingTween = Camera.main.transform.DOMove(charactersCameraPos[app.TavernModel.curentIndex].position, 1f);
        rotationTween =  Camera.main.transform.DORotate(charactersCameraPos[app.TavernModel.curentIndex].eulerAngles, 1f);
        uiController.FillCharacterData(app.TavernModel.characters[app.TavernModel.curentIndex]);
        uiController.OpenChooseCharacterPanel();

        if (app.TavernModel.curentIndex == 0)
        {
            uiController.leftBtn.interactable = false;
        }
        else {
            uiController.leftBtn.interactable = true;
        }

        if (app.TavernModel.curentIndex == playersSpawnPlaces.Length - 1)
        {
            uiController.rightBtn.interactable = false;
        }
        else
        {
            uiController.rightBtn.interactable = true;
        }
    }

    private void KillCameraMoving() { 
        movingTween.Kill();
        rotationTween.Kill();
    }

    public void MoveRight() {
        app.TavernModel.curentIndex = Mathf.Clamp(app.TavernModel.curentIndex + 1, 0, playersSpawnPlaces.Length - 1);
        ComeClose();
    }

    public void MoveLeft() {
        app.TavernModel.curentIndex = Mathf.Clamp(app.TavernModel.curentIndex - 1, 0, playersSpawnPlaces.Length - 1);
        ComeClose();
    }

    public void BuyEffect(bool result) {
        if (result)
        {
            uiController.BuyEffect();

            SetDefault();
            playerViews[app.TavernModel.curentIndex].GetComponent<Animator>().SetTrigger("stand");
            DOVirtual.Float(0, 1, 2.1f, (_value) => { }).OnComplete(() => {
                FindObjectOfType<SceneManager>().LoadScene(Scene.CoreGame);
            });
        }
        else {
            uiController.BuyErrorEffect();
        }
    }
}

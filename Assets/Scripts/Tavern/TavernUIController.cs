using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TavernUIController : MonoBehaviour
{
    //стартовое меню
    [SerializeField] private Button backToGameBtn;
    [SerializeField] private GameObject startMenuPanel;
    //меню выбора персонажа
    [SerializeField] private GameObject chooseCharacterPanel;
    [SerializeField] public Button backToMainPanelBtn;
    [SerializeField] public Button leftBtn;
    [SerializeField] public Button rightBtn;

    [SerializeField] public Button buyBtn;

    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterParametrs;
    [SerializeField] private TextMeshProUGUI characterStory;
    [SerializeField] private TextMeshProUGUI characterCost;

    [SerializeField] private TextMeshProUGUI moneyText;

    private int currentCost;
    private PlayerInformation PlayerInformation;
    private void Start()
    {
        PlayerInformation = FindObjectOfType<PlayerInformation>();
        moneyText.text = PlayerInformation.playerData.money.ToString();
        backToGameBtn.onClick.AddListener(() => {
            FindObjectOfType<SceneManager>().LoadScene(Scene.CoreGame);
        });

        backToMainPanelBtn.onClick.AddListener(() => {
            OpenStartMenuPanel();
        });

    }

    public void OpenChooseCharacterPanel() {
        startMenuPanel.SetActive(false);
        chooseCharacterPanel.SetActive(true);
    }

    public void OpenStartMenuPanel() {
        chooseCharacterPanel.SetActive(false);
        startMenuPanel.SetActive(true);
    }

    public void FillCharacterData(Character character) {
        characterName.text = character.name;
        characterParametrs.text = "hp\t\t\t" + character.HP.ToString() +
            "\nenergy\t\t\t" + character.energy.ToString();
        characterStory.text = character.story;
        characterCost.text = "cost\t\t" + character.cost.ToString();
        currentCost = character.cost;
    }

    public void BuyEffect() {
        DOVirtual.Float(PlayerInformation.playerData.money, PlayerInformation.playerData.money - currentCost, 1f, (_value) => {
            moneyText.text = ((int)_value).ToString();
        });
    }

    public void BuyErrorEffect() {
        moneyText.DOColor(Color.red, 0.5f)
            .OnComplete(() => {
                moneyText.DOColor(Color.white, 0.5f);
            });
    }
}

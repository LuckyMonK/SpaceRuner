using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TavernView : TavernElement
{
    [SerializeField] private Transform firstCameraPos;

    [SerializeField] public Transform[] playersSpawnPlaces;
    [SerializeField] private RuntimeAnimatorController PlayerAnimationController;
    [SerializeField] private List<GameObject> playerViews;
    public void FirstCameraMove() {
        Camera.main.transform.DOMove(firstCameraPos.position, 1f);
        Camera.main.transform.DORotate(firstCameraPos.eulerAngles, 1f);
    }

    public void CreateCharactersView() {
        for (int i = 0; i < playersSpawnPlaces.Length; i++) {
            playerViews.Add(Instantiate(app.TavernModel.characters[i].viewPrefab, 
                playersSpawnPlaces[i].position, playersSpawnPlaces[i].rotation));
            //app.TavernModel.characters[i].viewPrefab = view;
            playerViews[i].transform.parent = playersSpawnPlaces[i];
            var tempAnim = playerViews[i].GetComponent<Animator>();
            tempAnim.runtimeAnimatorController = PlayerAnimationController;

            tempAnim.SetInteger("state", Random.Range(0, 2));
            tempAnim.SetTrigger("sitting");
        }
    }
}

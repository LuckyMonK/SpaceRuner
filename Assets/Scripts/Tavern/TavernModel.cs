using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernModel : TavernElement
{
    public List<Character> characters;
    public CharactersData data;

    public int curentIndex;

    public PlayerInformation playerInformation;
    
    public void FillData() {
        for (int i = 0; i < app.TavernView.playersSpawnPlaces.Length; i++) {
            //int rn = Random.Range(0, charCopy.Count);

            //characters.Add(charCopy[rn]);
            //charCopy.RemoveAt(rn);

            AddUniqCharacter();
        }

        playerInformation = FindObjectOfType<PlayerInformation>();
    }

    private void AddUniqCharacter() {
        int rn = Random.Range(0, data.characters.Count);
        if (characters.Contains(data.characters[rn]))
        {
            AddUniqCharacter();
            return;
        }
        else {
            characters.Add(data.characters[rn]);
        }
    }

    
}

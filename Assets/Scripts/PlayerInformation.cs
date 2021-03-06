using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public static PlayerInformation Instantiate;
    public Player playerData;

    private void Awake()
    {
        if (!Instantiate) {
            Instantiate = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class Player { 
    public string nickName;
    public int level;
    public Character character;
    public Weapon weapon;
    public int money;
}

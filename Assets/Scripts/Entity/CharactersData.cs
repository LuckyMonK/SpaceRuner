using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersData", menuName = "ScriptableObjects/CharactersData", order = 2)]
public class CharactersData : ScriptableObject
{
    public List<Character> characters;
}

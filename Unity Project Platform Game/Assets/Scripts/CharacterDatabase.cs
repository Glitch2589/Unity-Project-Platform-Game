using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CharacterInformation[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public CharacterInformation GetCharacter(int index)
    {
        return character[index];
    }

}

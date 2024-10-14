using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCCharacterSO", menuName ="CharacterData/NPC",order = 1)]
public class NpcCharacterSO : CharacterSO
{
    [Header("DialogData")]
    public List<string> DialogList;

}

using UnityEngine;

[CreateAssetMenu(fileName = "DafaultCharacterSO", menuName ="CharacterData/Default",order = 0)]
public class CharacterSO : ScriptableObject
{
    [Header("Character Data")]
    public string name;
    public float speed;

}

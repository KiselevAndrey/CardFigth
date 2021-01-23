using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardSO : ScriptableObject
{
    [Header("Общие данные")]
    public Sprite backGround;
    public Sprite avatar;
    public string nameAvatar;
    [TextArea(1, 5)] public string description;
    
    [Header("Атака")]
    public StatsSO statsAttack;
    public int valueAttack;
    
    [Header("Защита")]
    public StatsSO statsDefense;
    public int valueDefense;

    [Header("Доп значения")]
    public int valueHealth;
    public int valueManaCost;
}

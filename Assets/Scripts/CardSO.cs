﻿using UnityEngine;

[CreateAssetMenu(fileName ="Card")]
public class CardSO : ScriptableObject
{
    [Header("Общие данные")]
    public Sprite backGround;
    public Sprite avatar;
    public string nameCardAvatar;
    [TextArea(1, 5)] public string description;
    
    [Header("Атака")]
    public StatsSO statsAttack;
    public int valueAttack;
    
    [Header("Жизнь")]
    public StatsSO statsHealth;
    public int valueHealth;
}

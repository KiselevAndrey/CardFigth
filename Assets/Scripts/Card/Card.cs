using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("Данные карты")]
    [SerializeField] Image backGround;
    [SerializeField] Image avatar;
    [SerializeField] Text cardName;
    [SerializeField] Text cardDescription;

    [Header("Скрипты атаки, защиты и здоровья")]
    public Attack attack;
    public Defense defense;
    public Health health;

    //[SerializeField, Min(0)] int manaCost;
    
    CardSO _card;

    public CardSO card { get => _card; }

    /// <summary>
    /// Заполнение карты
    /// </summary>
    /// <param name="_card"></param>
    public void FillingCard(CardSO newCard)
    {
        _card = newCard;

        backGround.sprite = _card.backGround;
        avatar.sprite = _card.avatar;
        
        attack.UpdateStat(_card.statsAttack, _card.valueAttack);
        defense.UpdateStat(_card.statsDefense, _card.valueDefense);
        health.UpdateValue(_card.valueHealth);

        cardName.text = _card.nameCardAvatar;
        cardDescription.text = _card.description;
    }

    public int Attack(Defense enemyDefense)
    {
        return attack.GetDamage(enemyDefense);
    }

    public int Attack(Attack enemyAttack)
    {
        return defense.GetDamage(enemyAttack);
    }
}

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

    /// <summary>
    /// Заполнение карты
    /// </summary>
    /// <param name="newCard"></param>
    public void FillingCard(CardSO newCard)
    {
        backGround.sprite = newCard.backGround;
        avatar.sprite = newCard.avatar;
        
        attack.UpdateStat(newCard.statsAttack, newCard.valueAttack);
        defense.UpdateStat(newCard.statsDefense, newCard.valueDefense);

    }
}

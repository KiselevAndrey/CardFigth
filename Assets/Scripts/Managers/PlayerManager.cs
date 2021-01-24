using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Карты")]
    [SerializeField] Card currentCard;
    [SerializeField] Card leftCard;
    [SerializeField] Card rightCard;

    [Header("Доп объекты")]
    [SerializeField] PlayerHandSO hand;
    
    void Start()
    {
        hand.Zeroing();

        NextCard(ref currentCard);
        NextCard(ref leftCard);
        NextCard(ref rightCard);
    }

    public void NextCard(ref Card card)
    {
        if (!hand.HaveCard(CardType.GivenOut))
        { 
            card.gameObject.SetActive(false);
            return;
        }
                
        card.FillingCard(hand.NextCard());
    }

    /// <summary>
    /// Меняет выбранную карту с центральной
    /// </summary>
    /// <param name="card"></param>
    public void ReplaceCard(Card card)
    {
        //if (currentCard.health.Value > 0) return;

        currentCard.FillingCard(card.card);
        NextCard(ref card);
    }

    public void StartCurrentCardAnim(string animName)
    {

        if (currentCard.health.IsLife())
            currentCard.GetComponent<Animator>().Play(animName);
    }
}

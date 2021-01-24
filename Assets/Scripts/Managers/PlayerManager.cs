using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Карты")]
    [SerializeField] Card currentCard;
    [SerializeField] Card leftCard;
    [SerializeField] Card rightCard;

    [Header("Доп объекты")]
    [SerializeField] PlayerHandSO playerHand;

    [SerializeField] bool infinityPlayerHand;

    void Start()
    {
        playerHand.Shuffle();

        NextCard(ref currentCard);
        NextCard(ref leftCard);
        NextCard(ref rightCard);
    }

    public void NextCard(ref Card card)
    {
        if (!playerHand.CanGetNextCard())
        {
            if (infinityPlayerHand) playerHand.Shuffle();
            else
            {
                card.gameObject.SetActive(false);
                return;
            }
        }
        
        card.FillingCard(playerHand.NextCard());
    }

    /// <summary>
    /// Меняет выбранную карту с центральной
    /// </summary>
    /// <param name="card"></param>
    public void ReplaceCard(Card card)
    {
        if (currentCard.health.Value > 0) return;

        currentCard.FillingCard(card.card);
        NextCard(ref card);
    }

    public void StartCurrentCardAnim(string animName)
    {
        currentCard.GetComponent<Animator>().Play(animName);
    }
}

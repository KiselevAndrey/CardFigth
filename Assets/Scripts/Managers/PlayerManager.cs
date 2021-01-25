using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Карты")]
    [SerializeField] public Card currentCard;
    [SerializeField] Card leftCard;
    [SerializeField] Card rightCard;

    [Header("Доп объекты")]
    [SerializeField] public HandSO hand;
    [SerializeField] public string playerName;

    [Header("Данные для бота или второго игрока")]
    [Tooltip("За игрока играет бот?")] public bool isBot;
    [SerializeField, Tooltip("Переворачивать карты на 180?")] bool isShifter;
    [SerializeField] Direction direction;

    Animator _animCurrentCard;

    void Start()
    {
        hand.Zeroing();

        NextCard(ref currentCard);
        NextCard(ref leftCard);
        NextCard(ref rightCard);

        _animCurrentCard = currentCard.GetComponent<Animator>();

        _animCurrentCard.SetBool("isShifter", isShifter);
        _animCurrentCard.SetBool("isUpDirection", direction == Direction.Up);

        if (isShifter) Turned();
    }

    void Turned()
    {
        //float degrees = 180;
        //Vector3 to = new Vector3(0, 0, degrees );
        //currentCard.transform.rotation = Quaternion.Inverse(currentCard.transform.rotation);
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
        hand.AddDeath();

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

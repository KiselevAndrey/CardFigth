using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] PlayerHandSO hand;

    // Start is called before the first frame update
    void Start()
    {
        hand.Shuffle();
        card.FillingCard(hand.NextCard());
    }
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Hand")]
public class PlayerHandSO : ScriptableObject
{
    [SerializeField, Range(0, 20)] int maxCardsCount;

    public List<CardSO> _cards;
    int _i = 0;

    public void Shuffle()
    {
        _i = 0;
        _cards.Shuffle();
    }

    public CardSO NextCard()
    {
        CardSO temp = _cards[_i++];
        
        return temp;
    }

    public void AddCard(CardSO card)
    {
        if (_cards.Count < maxCardsCount) _cards.Add(card);
    }

    public bool CanGetNextCard() => _i < _cards.Count && _i < maxCardsCount;
}

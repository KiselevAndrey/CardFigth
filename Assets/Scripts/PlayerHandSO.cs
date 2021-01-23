using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerHandSO : ScriptableObject
{
    [SerializeField, Range(0, 20)] int maxCardsCount;

    public List<CardSO> _cards;
    int _i;

    public void Shuffle()
    {
        _i = 0;
        _cards.Shuffle();
    }

    public CardSO NextCard()
    {
        CardSO temp = _cards[_i];

        if (_i >= _cards.Count) Shuffle();

        return temp;
    }

    public void AddCard(CardSO card)
    {
        if (_cards.Count < maxCardsCount) _cards.Add(card);
    }
}

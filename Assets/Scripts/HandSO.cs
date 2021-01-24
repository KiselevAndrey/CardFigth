using System.Collections.Generic;
using UnityEngine;

public enum CardType { GivenOut, Life }

[CreateAssetMenu(fileName ="Hand")]
public class HandSO : ScriptableObject
{
    [SerializeField, Range(0, 20)] int maxCardsCount;
    public void SetMaxCardsCount(int value)
    {
        if (value < 0) maxCardsCount = 0;
        else if (value > 20) maxCardsCount = 20;
        else maxCardsCount = value;
    }

    [SerializeField] bool infinityHand;

    public List<CardSO> _cards;
    int _i = 0;
    int _givenOutCardsCount = 0;
    int _deathCardCount = 0;

    public void Zeroing()
    {
        _i = _givenOutCardsCount = _deathCardCount = 0;

        _cards.Shuffle();
    }

    public CardSO NextCard()
    {
        CardSO temp = _cards[_i++];
        _givenOutCardsCount++;

        if(infinityHand && _i >= _cards.Count)
        {
            _i = 0;
            _cards.Shuffle();
        }
        
        return temp;
    }

    public void AddCard(CardSO card)
    {
        if (_cards.Count < maxCardsCount) _cards.Add(card);
    }

    public bool HaveCard(CardType type)
    {
        switch (type)
        {
            case CardType.GivenOut:
                return HaveCard(_givenOutCardsCount);
            case CardType.Life:
                return HaveCard(_deathCardCount);
        }

        return false;
    }

    bool HaveCard(int count) => count < _cards.Count || (infinityHand && count < maxCardsCount);

    /// <summary>
    /// Количество живых карт
    /// </summary>
    /// <returns></returns>
    public int CountOfRemainingCard()
    {
        return infinityHand ? maxCardsCount - _deathCardCount : _cards.Count - _deathCardCount;
    }

    public void AddDeath() => _deathCardCount++;
}

﻿using UnityEngine;

enum TypeFight { Attack, Defense }
public class FightManager : MonoBehaviour
{
    [Header("Данные игроков")]
    [SerializeField] PlayerManager playerUp;
    [SerializeField] PlayerManager playerDown;

    [Header("Доп данные")]
    [SerializeField, Tooltip("На что будет реагировать множитель")] TypeFight typeFight;
    [SerializeField] WinnerLogSO winnerLog;
    [SerializeField] SceneManagerSO sceneManager;
    [SerializeField] Object afterGameScene;

    bool _stepUp;

    public void Attack()
    {
        if (!_stepUp || playerDown.isBot)
        {
            Attack(ref playerDown.currentCard, ref playerUp.currentCard);
            _stepUp = true;
        }
        if (_stepUp || playerUp.isBot)
        {
            Attack(ref playerUp.currentCard, ref playerDown.currentCard);
            _stepUp = false;
        }
        
        TryWin();
    }

    void Attack(ref Card first, ref Card second)
    {
        int damage = 0;

        switch (typeFight)
        {
            case TypeFight.Attack:
                damage = first.Attack(second.defense);
                break;
            case TypeFight.Defense:
                damage = second.Attack(first.attack);
                break;
        }

        second.health.GetDamage(damage);
    }

    void TryWin()
    {
        if (UpdateWin(playerUp.currentCard, playerDown.currentCard, playerDown.hand))
        {
            UpdateWinnerLog(playerUp.playerName, playerUp.hand.CountOfRemainingCard());
        }

        else if (UpdateWin(playerDown.currentCard, playerUp.currentCard, playerUp.hand))
        {
            UpdateWinnerLog(playerDown.playerName, playerDown.hand.CountOfRemainingCard());
        }
    }

    void UpdateWinnerLog(string name, int remaningCard)
    { 
        winnerLog.winerName = name;
        winnerLog.countOfRemainingCarg = remaningCard;
        sceneManager.LoadScene(afterGameScene.name);
    }

    /// <summary>
    /// Выигрывает first, если second умер и у него на руке больше нет карт
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="secondHand"></param>
    /// <returns></returns>
    bool UpdateWin(Card first, Card second, HandSO secondHand)
    {
        bool healtLessZero = !second.health.IsLife();
        if (healtLessZero) secondHand.AddDeath();

        return first.health.IsLife() && healtLessZero && !secondHand.HaveCard(CardType.Life);
    }
}

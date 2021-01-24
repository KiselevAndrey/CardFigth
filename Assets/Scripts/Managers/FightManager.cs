using UnityEngine;

enum TypeFight { Attack, Defense }
public class FightManager : MonoBehaviour
{
    [Header("Данные противника")]
    [SerializeField] Card enemy;
    [SerializeField] PlayerHandSO enemyHand;

    [Header("Данные игрока")]
    [SerializeField] Card player;
    [SerializeField] PlayerHandSO playerHand;

    [Header("Доп данные")]
    [SerializeField, Tooltip("На что будет реагировать множитель")] TypeFight typeFight;
    [SerializeField] WinnerLogSO winnerLog;
    [SerializeField] SceneManagerSO sceneManager;
    [SerializeField] Object afterGameScene;

    public void Attack()
    {
        Attack(ref player, ref enemy);
        Attack(ref enemy, ref player);
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
            default:
                break;
        }

        second.health.GetDamage(damage);
    }

    void TryWin()
    {
        //print("player " + player.health.Value.ToString() + " " + playerHand.CanGetNextCard());
        //print("enemy " + enemy.health.Value.ToString() + " " + enemyHand.CanGetNextCard());

        if (UpdateWin(player, enemy, enemyHand))
        {
            UpdateWinnerLog(player, playerHand);
        }

        else if (UpdateWin(enemy, player, playerHand))
        {
            UpdateWinnerLog(enemy, enemyHand);
        }
    }

    void UpdateWinnerLog(Card card, PlayerHandSO hand)
    { 
        winnerLog.winerName = card.card.nameCardAvatar;
        winnerLog.countOfRemainingCarg = hand.CountOfRemainingCarg();
        sceneManager.LoadScene(afterGameScene.name);
    }

    /// <summary>
    /// Выигрывает first, если second умер и на руке больше нет карт
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <param name="secondHand"></param>
    /// <returns></returns>
    bool UpdateWin(Card first, Card second, PlayerHandSO secondHand)
    {
        bool healtLessZero = second.health.Value <= 0;
        if (healtLessZero) secondHand.AddDeath();

        return first.health.Value > 0 && healtLessZero && !secondHand.HaveCard(CardType.Life);
    }
}

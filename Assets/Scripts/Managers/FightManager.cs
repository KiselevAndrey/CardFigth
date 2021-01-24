using UnityEngine;

enum TypeFight { Attack, Defense }
public class FightManager : MonoBehaviour
{
    [SerializeField] Card enemy;
    [SerializeField] Card player;

    [SerializeField, Tooltip("На что будет реагировать множитель")] TypeFight typeFight;

    public void Attack()
    {
        Attack(ref player, ref enemy);
        Attack(ref enemy, ref player);
    }

    void Attack(ref Card first, ref Card second)
    {
        int damage = 0;
        switch (typeFight)
        {
            case TypeFight.Attack:
                damage = first.attack.GetDamage(second.defense);
                break;
            case TypeFight.Defense:
                damage = second.defense.GetDamage(first.attack);
                break;
            default:
                break;
        }

        second.health.GetDamage(damage);
    }

    void TryWin()
    {

    }
}

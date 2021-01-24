using UnityEngine;

[CreateAssetMenu(fileName = "Stat")]
public class StatsSO : ScriptableObject
{
    [Header("Зависимости статов")]
    [Tooltip("Основной стат"), SerializeField] Stats currentStat;
    [Tooltip("Стат побеждающий основной стат"), SerializeField] Stats winingStat;
    [Tooltip("Стат проигрывающий основному стату"), SerializeField] Stats lossingStat;

    [Header("Дополнительные данные")]
    [Tooltip("Цвет стата"), SerializeField] Color color;

    public Stats CurrentStat { get => currentStat; }
    public Color Color { get => color; }

    /// <summary>
    /// Возвращает множитель победы для текущего стата в зависимости от получаемого стата.
    /// Выигрывающий стат увеличивает множитель.
    /// </summary>
    /// <param name="getingStat"></param>
    /// <returns></returns>
    public float GetWinMultiply(Stats getingStat)
    {
        if (getingStat == winingStat) return 2f;
        else if (getingStat == lossingStat) return 0.5f;
        else return 1f;
    }

    /// <summary>
    /// Возвращает множитель проигрыша для текущего стата в зависимости от получаемого стата.
    /// Проигрывающий стат увеличивает множитель.
    /// </summary>
    /// <param name="getingStat"></param>
    /// <returns></returns>
    public float GetLossMultiply(Stats getingStat)
    {
        if (getingStat == winingStat) return 0.5f;
        else if (getingStat == lossingStat) return 2f;
        else return 1f;
    }
}

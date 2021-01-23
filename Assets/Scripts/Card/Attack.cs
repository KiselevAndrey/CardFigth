using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [Header("Привязки (Bindings)")]
    [SerializeField, Tooltip("Куда будет отображаться значение")] Text text;
    [SerializeField, Tooltip("Картинка для цветовой дифференциации стата")] Image imageStat;

    StatsSO _stat;
    int _value;

    public int Value { get => _value; }
    public StatsSO StatsSO { get => _stat; }

    /// <summary>
    /// Обновление привязок
    /// </summary>
    void UpdateBinding()
    {
        text.text = _value.ToString();
        imageStat.color = _stat.Color;
    }

    public void UpdateStat(StatsSO stat, int value)
    {
        _stat = stat;
        _value = value;

        UpdateBinding();
    }
}

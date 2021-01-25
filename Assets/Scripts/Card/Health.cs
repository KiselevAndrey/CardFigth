using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Привязки")]
    [SerializeField, Tooltip("Куда будет отображаться значение")] Text textValue;
    [SerializeField, Tooltip("Отображение урона")] Text textDamage;
    [SerializeField, Tooltip("Картинка для цветовой дифференциации стата")] Image imageStat;
    [SerializeField] Animator anim;

    StatsSO _stat;
    int _value;

    public int Value { get => _value; }
    public StatsSO StatsSO { get => _stat; }

    #region Updates
    public void UpdateStat(StatsSO stat, int value)
    {
        _stat = stat;
        UpdateValue(value);        
        imageStat.color = _stat.Color;
    }

    public void UpdateValue(int newValue)
    {
        _value = newValue;
        UpdateText();
    }

    void UpdateText()
    {
        anim.SetInteger("health", _value);
        textValue.text = _value.ToString();
    }
    #endregion
    
    public void GetDamage(int damage, Color color)
    {
        _value -= damage;

        textDamage.text = damage.ToString();
        color.a = 1;
        textDamage.color = color;

        anim.Play("damageUp");

        if (_value <= 0) _value = 0;
        
        UpdateText();
    }

    public bool IsLife() => _value > 0;
}

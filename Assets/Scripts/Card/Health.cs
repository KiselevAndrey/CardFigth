using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Привязки")]
    [SerializeField, Tooltip("Куда будет отображаться значение")] Text text;

    int _value;
    public int Value { get => _value; }

    void UpdateText()
    {
        text.text = _value.ToString();
    }

    public void UpdateValue(int newValue)
    {
        _value = newValue;
        UpdateText();
    }

    public void GetDamage(int damage)
    {
        _value -= damage;

        if (_value <= 0) _value = 0;

        UpdateText();
    }
}

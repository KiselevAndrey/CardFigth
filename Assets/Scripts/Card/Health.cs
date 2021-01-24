using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Привязки")]
    [SerializeField, Tooltip("Куда будет отображаться значение")] Text text;
    [SerializeField] Animator anim;

    int _value;
    public int Value { get => _value; }

    void UpdateText()
    {
        anim.SetInteger("health", _value);
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

        if (_value <= 0)
        {
            _value = 0;
        }

        UpdateText();
    }

    public bool IsLife() => _value > 0;
}

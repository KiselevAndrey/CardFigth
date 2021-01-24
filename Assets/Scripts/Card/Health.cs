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
        GetComponent<Animator>().SetInteger("health", _value);

        //print(gameObject.name);
        //print(GetComponent<Animator>().GetInteger("health").ToString() + " " + _value.ToString());

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
}

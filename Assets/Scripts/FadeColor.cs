using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeColor : MonoBehaviour
{
    [SerializeField] Image changedImade;
    [SerializeField] List<Image> images;
    [SerializeField, Min(1)] int slowestIndex;
    [SerializeField] float percentChanger = 0.01f;

    List<Color> _colors = new List<Color>();
    Color _requiredColor, _currentColor;
    int _countFrame;
    int _indexColor;
    float _percent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Count; i++)
            _colors.Add(images[i].color);

        _countFrame = 0;
        _indexColor = 0;

        NextColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(_countFrame <= slowestIndex)
        {
            _countFrame = 0;
            NextColorStep();
        }

        _countFrame++;
    }

    void NextIndex()
    {
        _indexColor++;

        if (_indexColor >= _colors.Count)
            _indexColor = 0;
    }

    void NextColor()
    {
        _currentColor = _colors[_indexColor];
        NextIndex();
        _requiredColor = _colors[_indexColor];
        _percent = 0;
    }

    /// <summary>
    /// Плавное изменение цвета основная функция
    /// </summary>
    /// <returns>Новый цвет от процентного смешивания двух цветов </returns>
    void NextColorStep()
    {
        _percent += percentChanger;

        if (_percent > 1f || _percent < 0f)
        {
            NextColor();
            _percent = 0f;
        }

        FadeToColor();
    }

    /// <summary>
    /// Процентное изменение цвета от текущего к требующемуся
    /// </summary>
    /// <returns>Новый цвет от процентного смешивания двух цветов </returns>
    void FadeToColor()
    {
        float r = _requiredColor.r * _percent + _currentColor.r * (1f - _percent);
        float g = _requiredColor.g * _percent + _currentColor.g * (1f - _percent);
        float b = _requiredColor.b * _percent + _currentColor.b * (1f - _percent);

        changedImade.color = new Color(r, g, b);
    }
}

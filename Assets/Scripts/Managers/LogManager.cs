using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] WinnerLogSO winnerLog;

    // Start is called before the first frame update
    void Start()
    {
        string currentText = "Game Over!";
        currentText += "\nПобедитель:\n" + winnerLog.winerName;
        currentText += "\nУ него осталось карт:\n" + winnerLog.countOfRemainingCarg;

        text.text = currentText;
    }
}

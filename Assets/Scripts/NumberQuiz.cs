using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberQuiz : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text firstNum = null;
    [SerializeField] private Text secondNum = null;
    [SerializeField] private Text resultNum = null;

    public void SetValue(Sentence<int> sentence, EmptyNumber empty) =>
        SetValue(sentence.FirstNum, sentence.SecondNum, sentence.Result, empty);

    public void SetValue(int firstVal = 0, int secondVal = 0, int resultVal = 0, EmptyNumber empty = EmptyNumber.None)
    {
        switch (empty)
        {
            case EmptyNumber.First:
                SetText(null, secondVal, resultVal);
                break;
            case EmptyNumber.Second:
                SetText(firstVal, null, resultVal);
                break;
            case EmptyNumber.Result:
                SetText(firstVal, secondVal, null);
                break;
            case EmptyNumber.None:
            default:
                SetText(firstVal, secondVal, resultVal);
                break;
        }
    }

    public void SetText(int? firstVal, int? secondVal, int? resultVal)
    {
        SetText(firstNum, firstVal);
        SetText(secondNum, secondVal);
        SetText(resultNum, resultVal);
    }

    private void SetText(Text text, int? val)
    {
        if (val == null) text.text = string.Empty;
        text.text = val.ToString();
    }
}

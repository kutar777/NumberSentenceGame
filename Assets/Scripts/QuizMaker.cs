using UnityEngine;
using UnityEngine.UI;

public class QuizMaker : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text firstNum  = null;
    [SerializeField] private Text secondNum = null;
    [SerializeField] private Text resultNum    = null;

    [Header("Debug")]
    [SerializeField] private int firstVal;
    [SerializeField] private int secondVal;

    public enum EmptyNumber : int
    {
        None,
        First,
        Second,
        Result
    }

    Addition addition = new Addition(1, 1);

    void Start() => SetValue(addition, EmptyNumber.None);

    // インスペクターで値入力
    public void UpdateNumbers()
    {
        //addition = new AddSentence(firstVal, secondVal);
        //SetText(addition);
    }

    // ランダム値入力
    public void UpdateNumbersRandomly()
    {
        int firstVal = Random.Range(0, 10);
        int secondVal = Random.Range(0, 10);
        addition = new Addition(firstVal, secondVal);
        SetValue(addition, (EmptyNumber)Random.Range(1, 4));
    }

    public void SetValue(Sentence<int> sentence, EmptyNumber empty) =>
        SetValue(addition.FirstNum, addition.SecondNum, addition.Result, empty);

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

    public void SetText(Text text, int? val)
    {
        if (val == null) text.text = string.Empty;
        text.text = val.ToString();
    }

}

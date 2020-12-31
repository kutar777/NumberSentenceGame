using UnityEngine;
using UnityEngine.UI;

public class NumberQuiz : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text firstNum = null;
    [SerializeField] private Text secondNum = null;
    [SerializeField] private Text resultNum = null;
    [SerializeField] private Image emptySpace = null;

    private void Awake()
    {
        SetActiveEmptySpace(false);
    }


    /// <summary>
    /// 計算問題と空欄をセットする
    /// </summary>
    /// <param name="sentence">計算問題</param>
    /// <param name="empty">空欄の位置</param>
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
        if (val == null) SetEmptyText(text);
        text.text = val.ToString();
    }

    private void SetEmptyText(Text text)
    {
        emptySpace.transform.position = text.transform.position;
        SetActiveEmptySpace(true);
    }

    public void SetActiveEmptySpace(bool enable) =>
        emptySpace.gameObject.SetActive(enable);
}

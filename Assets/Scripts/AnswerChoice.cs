using UnityEngine;
using UnityEngine.UI;

public class AnswerChoice : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text number = null;
    [SerializeField] private Text answer = null;

    public void SetText(int label, int answer)
    {
        SetLabel(label);
        SetAnswer(answer);
    }

    public void SetLabel(int val)
    {
        number.text = $"({val})";
    }

    public void SetAnswer(int val)
    {
        answer.text = val.ToString();
    }
}

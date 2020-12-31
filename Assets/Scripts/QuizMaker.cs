using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class QuizMaker : MonoBehaviour
{
    [Header("Quiz")]
    [SerializeField] GameObject quizPrefab = null;
    [SerializeField] List<Transform> quizPlaces = new List<Transform>();

    private List<NumberQuiz> quizzes;
    private Addition addition = new Addition(1, 1);

    [Header("Answer")]
    [SerializeField] GameObject anwerPrefab = null;
    [SerializeField] List<Transform> answerPlaces = new List<Transform>();

    private List<AnswerChoice> answers;

    void Start()
    {
        InitializeQuizList();
        InitializeAnswerChoices();
        UpdateQuizList();
    }

    private void InitializeQuizList()
    {
        if(quizzes != null)
        {
            quizzes.Clear();
            quizzes = null;
        }

        quizzes = new List<NumberQuiz>();
        foreach (var place in quizPlaces)
        {
            var go = Instantiate<GameObject>(quizPrefab, place);
            var quiz = go.GetComponent<NumberQuiz>();
            if (quiz != null) quizzes.Add(quiz);
        }
    }

    private void InitializeAnswerChoices()
    {
        if(answers != null)
        {
            answers.Clear();
            answers = null;
        }

        answers = new List<AnswerChoice>();
        foreach (var place in answerPlaces)
        {
            var go = Instantiate<GameObject>(anwerPrefab, place);
            var answer = go.GetComponent<AnswerChoice>();
            if (answer != null) answers.Add(answer);
        }
    }

    public void UpdateQuizList()
    {
        foreach (var quiz in quizzes)
        {
            int firstVal = UnityEngine.Random.Range(0, 10);
            int secondVal = UnityEngine.Random.Range(0, 10);
            addition = new Addition(firstVal, secondVal);
            //quiz.SetValue(addition, (EmptyNumber)UnityEngine.Random.Range(1, 4));
            quiz.SetValue(addition, EmptyNumber.Result);
            UpdateAnswers(addition.Result);
        }
    }

    private void UpdateAnswers(int result)
    {
        var ansWithIndex = answers.Select((ans, index) => new { index, ans });
        foreach (var item in ansWithIndex)
        {
            item.ans.SetText(item.index + 1, result + item.index);
        }
    }

    // ランダム値入力
    public void UpdateNumbersRandomly()
    {
        int firstVal = UnityEngine.Random.Range(0, 10);
        int secondVal = UnityEngine.Random.Range(0, 10);
        addition = new Addition(firstVal, secondVal);
        //SetValue(addition, (EmptyNumber)UnityEngine.Random.Range(1, 4));
    }
}

public enum EmptyNumber : int
{
    None,
    First,
    Second,
    Result
}
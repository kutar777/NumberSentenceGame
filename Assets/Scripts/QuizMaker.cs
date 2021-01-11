using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuizMaker : MonoBehaviour
{
    [Header("Quiz")]
    [SerializeField] GameObject quizPrefab = null;
    [SerializeField] List<Transform> quizPlaces = new List<Transform>();

    private List<NumberQuiz> quizzes;

    [Header("Answer")]
    [SerializeField] GameObject anwerPrefab = null;
    [SerializeField] List<Transform> answerPlaces = new List<Transform>();

    private List<AnswerChoice> answers;

    private List<Addition> _AdditionQuizzes = new List<Addition>();
    private int currentQuizNum = 0;

    // 残りのクイズ数
    public int LeftQuizNum => _AdditionQuizzes.Count - currentQuizNum;

    public Action OnQuizUpdated;

    void Awake()
    {
        InitializeQuizList();
        InitializeAnswerChoices();
    }

    //private void Start()
    //{
    //    CreateQuizzes(count: 3);
    //    UpdateQuizList();
    //}

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

    public List<Addition> CreateQuizzes(int count)
    {
        if (count < 1) throw new System.ArgumentOutOfRangeException();

        _AdditionQuizzes = Enumerable.Range(1, count).Select(i => CreateSingleQuizRandomly()).ToList();
        currentQuizNum = 0;

        return _AdditionQuizzes;
    }

    private Sentence<int> GetQuiz(int quizNum)
    {
        if (_AdditionQuizzes == null || _AdditionQuizzes.Count == 0)
            throw new System.Exception($"{nameof(_AdditionQuizzes)} is not initialized");

        if (quizNum >= _AdditionQuizzes.Count)
            throw new System.ArgumentOutOfRangeException();

        return _AdditionQuizzes.ElementAt(quizNum);
    }

    private Addition CreateSingleQuizRandomly()
    {
        int firstVal = UnityEngine.Random.Range(0, 10);
        int secondVal = UnityEngine.Random.Range(0, 10);
        return new Addition(firstVal, secondVal);
    }

    public void UpdateQuizList()
    {
        if (currentQuizNum >= _AdditionQuizzes.Count) return;

        foreach (var quiz in quizzes)
        {
            //Addition addition = CreateSingleQuizRandomly();
            var addition = GetQuiz(currentQuizNum);
            quiz.SetValue(addition, EmptyNumber.Result);
            UpdateAnswers(addition.Result);
            currentQuizNum++;
        }
        OnQuizUpdated.Invoke();
    }

    private void UpdateAnswers(int result)
    {
        var ansWithIndex = answers.Select((ans, index) => new { index, ans });
        var rand = UnityEngine.Random.Range(0, answers.Count()); // 正解の場所をランダムに決める
        foreach (var item in ansWithIndex)
        {
            item.ans.SetText(item.index + 1, result - rand + item.index);
        }
    }

    // ランダム値入力
    public void UpdateNumbersRandomly()
    {
        int firstVal = UnityEngine.Random.Range(0, 10);
        int secondVal = UnityEngine.Random.Range(0, 10);
        Addition addition = CreateSingleQuizRandomly();
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
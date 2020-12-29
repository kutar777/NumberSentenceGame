using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuizMaker : MonoBehaviour
{
    [SerializeField] GameObject quizPrefab = null;
    [SerializeField] List<Transform> places = new List<Transform>();

    private List<NumberQuiz> quizzes;

    [Header("Debug")]
    [SerializeField] private int firstVal;
    [SerializeField] private int secondVal;

    Addition addition = new Addition(1, 1);

    void Start()
    {
        InitializeQuizList();
        UpdateQuizList();
    }

    public void UpdateQuizList()
    {
        foreach (var quiz in quizzes)
        {
            int firstVal = UnityEngine.Random.Range(0, 10);
            int secondVal = UnityEngine.Random.Range(0, 10);
            addition = new Addition(firstVal, secondVal);
            quiz.SetValue(addition, (EmptyNumber)UnityEngine.Random.Range(1, 4));
        }
    }

    private void InitializeQuizList()
    {
        if(quizzes != null)
        {
            quizzes.Clear();
            quizzes = null;
        }

        quizzes = new List<NumberQuiz>();
        foreach (var place in places)
        {
            var go = Instantiate<GameObject>(quizPrefab, place);
            var quiz = go.GetComponent<NumberQuiz>();
            if (quiz != null) quizzes.Add(quiz);
        }
    }

    // インスペクターで値入力
    public void UpdateNumbers()
    {
        //addition = new AddSentence(firstVal, secondVal);
        //SetText(addition);
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
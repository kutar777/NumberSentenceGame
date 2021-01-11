using System;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] QuizMaker quizMaker = null;

    [Header("Min: 1, Max: 10")]
    [Range(min: 1, max: 10)]
    [SerializeField] int quizCount = 1;

    [Header("UI")]
    [SerializeField] Button nextQuizButton = null;
    [SerializeField] Button previouQuizButton = null;

    private void OnEnable()
    {
        quizMaker.OnQuizUpdated += OnQuizUpdated;
    }

    private void OnDisable()
    {
        quizMaker.OnQuizUpdated += OnQuizUpdated;
    }

    private void OnQuizUpdated()
    {
        Debug.Log($"LeftQuiz: {quizMaker.LeftQuizNum}");
        if (quizMaker.LeftQuizNum > 0)
            nextQuizButton.gameObject.SetActive(true);

    }

    void Start()
    {
        quizMaker.CreateQuizzes(quizCount);
        quizMaker.UpdateQuizList();
    }

    void Update()
    {
        
    }
}

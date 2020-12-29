using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string nextScene = string.Empty;

    [SerializeField] private UnityEvent OnSceneLoaded;
    [SerializeField] private UnityEvent OnSceneUnloaded;

    [ContextMenu("Load")]
    public void LoadNextScene()
    {
        if (string.IsNullOrEmpty(nextScene))
            throw new System.Exception("Next Scene is Empty");

        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);

        OnSceneLoaded?.Invoke();
    }

    public void UnloadScene()
    {
        if (string.IsNullOrEmpty(nextScene))
            throw new System.Exception("Next Scene is Empty");

        SceneManager.UnloadSceneAsync(nextScene, UnloadSceneOptions.None);
        Debug.Log($"Unload Scene: {nextScene}");

        OnSceneUnloaded?.Invoke();
    }
}

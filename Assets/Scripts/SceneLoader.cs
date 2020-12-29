using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string nextScene = string.Empty;

    [ContextMenu("Load")]
    public void LoadNextScene()
    {
        if (string.IsNullOrEmpty(nextScene))
            throw new System.Exception("Next Scene is Empty");

        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
    }
}

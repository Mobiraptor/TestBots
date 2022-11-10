using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    [SerializeField] private MoveLoadingBot loadingScript;

    void Start()
    {
        Button toMenuButton = GetComponent<Button>();
        toMenuButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        loadingScript.nextSceneName = "Game";
        SceneManager.LoadScene("Load", LoadSceneMode.Single);
    }
}

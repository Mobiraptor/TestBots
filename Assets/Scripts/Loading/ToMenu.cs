using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    private Button toMenuButton;
    [SerializeField] private MoveLoadingBot loadingScript;

    void Start()
    {
        Button toMenuButton = GetComponent<Button>();
        toMenuButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        loadingScript.nextSceneName = "Menu";
        SceneManager.LoadScene("Load", LoadSceneMode.Single);
    }


}

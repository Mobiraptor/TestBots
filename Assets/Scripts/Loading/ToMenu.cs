using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Скрипт кнопки перехода в меню
public class ToMenu : MonoBehaviour
{
    [SerializeField] private MoveLoadingBot loadingScript;

    void Start()
    {
        Button toMenuButton = GetComponent<Button>();
        toMenuButton.onClick.AddListener(TaskOnClick);
    }

    //При нажатии в скрипт движущегося бота передаётся параметр, задающий следующую сцену. Запуск сцены загрузки
    void TaskOnClick()
    {
        loadingScript.nextSceneName = "Menu";
        SceneManager.LoadScene("Load", LoadSceneMode.Single);
    }

    //Мда... можно же было в одном скрипте сделать...
    //Ну уже поздно. Потом. В будущем.
}

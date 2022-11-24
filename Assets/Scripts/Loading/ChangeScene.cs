using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //������ �� ������ �������� � �� �����, ������� ������ ���� ��������� �����
    //links on loading script and scene that should be loaded after loading
    [SerializeField] private MoveLoadingBot loadingScript;
    [SerializeField] private string _scene;

    //������������� ������. ���������� ������ ������� �� ������ � EventHandler
    //Button init. Adding listener to EventeHandler waiting for click on button
    void Start()
    {
        Button toMenuButton = GetComponent<Button>();
        toMenuButton.onClick.AddListener(TaskOnClick);
    }

    //��� ������� � ������ ����������� ���� ��������� ��������, �������� ��������� �����. ������ ����� ��������
    //On button click passes to loading script scene that should be loaded after loading. Starting loading scene
    void TaskOnClick()
    {
        loadingScript.nextSceneName = _scene;
        SceneManager.LoadScene("Load", LoadSceneMode.Single);
    }
}

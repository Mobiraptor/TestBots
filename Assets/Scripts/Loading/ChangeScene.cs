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

    void Start()
    {
        Button toMenuButton = GetComponent<Button>();
        toMenuButton.onClick.AddListener(TaskOnClick);
    }

    //��� ������� � ������ ����������� ���� ��������� ��������, �������� ��������� �����. ������ ����� ��������
    void TaskOnClick()
    {
        loadingScript.nextSceneName = _scene;
        SceneManager.LoadScene("Load", LoadSceneMode.Single);
    }
}

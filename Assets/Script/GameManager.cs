using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public enum Stage { None, Child, Student, Adult, Grandpa }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /* Get int ���� �� 0�̸� clear ���� �� ��, 1�̸� clear �Ǿ����� */

    /// <summary>
    /// �� �������� �������� �־��ּ���
    /// </summary>
    /// <param name="stage"></param>
    public void SetStageClear(Stage stage)
    {
        PlayerPrefs.SetInt(stage.ToString(), 1);
    }

    public bool GetStageClear(Stage stage)
    {
        if (PlayerPrefs.GetInt(stage.ToString()) == 0)
            return false;
        else
            return true;
    }
}

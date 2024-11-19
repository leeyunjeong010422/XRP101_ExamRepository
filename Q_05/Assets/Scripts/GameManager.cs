using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.WebRequestMethods;

public class GameManager : SingletonBehaviour<GameManager>
{
    private const string ScoreKey = "Score"; //씬이 전환되어도 회전 속도는 저장
    public float Score { get; set; }

    private void Awake()
    {
        LoadScore();
    }

    private void LoadScore()
    {
        //https://docs.unity3d.com/kr/2022.3/ScriptReference/PlayerPrefs.GetFloat.html
        Score = PlayerPrefs.GetFloat(ScoreKey, 0.1f);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}

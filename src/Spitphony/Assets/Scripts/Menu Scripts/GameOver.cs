using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        LevelManager.Instance.LoadScene(LevelManager.Stage1SceneName);
        LevelManager.Instance.LoadSceneAdditive(LevelManager.MusicalEnvSceneName);
    }
}

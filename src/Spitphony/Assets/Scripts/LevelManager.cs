using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public const string MainMenuSceneName = "MenuScene";
    public const string StorySceneName = "BackstoryScene";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

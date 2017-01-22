using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
	public const string MainMenuSceneName = "MenuScene";
	public const string StorySceneName = "BackstoryScene";
	public const string Stage1SceneName = "Area1Scene";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    private static LevelManager _instance;
    private static object _creationLock = new object();
    private static bool _stillAlive = true;

    public static LevelManager Instance
    {
        get
        {
            lock (_creationLock)
            {
                if (_instance != null)
                    return _instance;

                var objects = FindObjectsOfType<LevelManager>();

                if (objects.Length > 0)
                {
                    _instance = objects[0];

                    if (objects.Length > 1)
                    {
                        for (int i = 1; i < objects.Length; ++i)
                            Destroy(objects[i].gameObject);

                        return _instance;
                    }
                }

                if (_stillAlive)
                {
                    var go = new GameObject();
                    go.name = typeof(LevelManager).Name;
                    _instance = go.AddComponent<LevelManager>();
                }
            }

            return _instance;
        }
    }

    void OnApplicationQuit()
    {
        _stillAlive = false;
    }
    #endregion

    public const string MainMenuSceneName = "MenuScene";
    public const string StorySceneName = "BackstoryScene";
    public const string Stage1SceneName = "Area1Scene";

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

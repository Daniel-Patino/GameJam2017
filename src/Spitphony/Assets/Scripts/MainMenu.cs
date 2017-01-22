using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadBackstoryScene()
    {
        LevelManager.Instance.LoadScene(LevelManager.StorySceneName);
    }
}

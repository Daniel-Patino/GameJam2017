using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StoryMenu : MonoBehaviour
{
	public void LoadArea1Scene()
	{
		LevelManager.Instance.LoadScene(LevelManager.Stage1SceneName);
	}
}

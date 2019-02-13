using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	public void loadLevel(string level)
 	{
    	SceneManager.LoadScene(level);
 	}

 	public void exit()
 	{
 		Application.Quit();
 	}
}

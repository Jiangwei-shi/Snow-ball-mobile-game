using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
	
	  public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
		Debug.Log("Retry");
    }

	public void BackToMenu()
	{
		SceneManager.LoadScene("StartScene");
	}
}

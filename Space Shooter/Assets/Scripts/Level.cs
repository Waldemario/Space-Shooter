using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	public void LoadGameScene()
	{
		SceneManager.LoadScene("GameScene");
		FindObjectOfType<ScoreCounter>().ResetScore();
	}

	public void LoadGameOver()
	{
		StartCoroutine(LoadDead());
	}

	public void LoadStartMenu()
	{
		SceneManager.LoadScene("StartMenu");
		FindObjectOfType<ScoreCounter>().ResetScore();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	IEnumerator LoadDead()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("GameOver");

	}
}

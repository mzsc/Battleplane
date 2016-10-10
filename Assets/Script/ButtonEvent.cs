using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
	public void EnterTetris ()
	{
		Application.LoadLevel ("Tetris");
		//SceneManager.LoadScene ("Tetris");
	}

	public void EnterGamesStart ()
	{
		Application.LoadLevel ("GamesStart");
		//SceneManager.LoadScene ("GamesStart");
	}

	public void EnterPlaneWar ()
	{
		Application.LoadLevel ("PlaneWar");
		//SceneManager.LoadScene ("PlaneWar");
	}

	public void GameOver ()
	{
		Application.Quit ();
	}
}

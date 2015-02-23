using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject humanPlayer;
	public GameObject computerPlayer;
	public Text gameOverMessage;
	public Text restartMessage;

	private string humanPlayerName;
	private string computerPlayerName;
	private bool gameOver;
	private bool humanPlayerWon;
	private bool gameOverMessageDisplayed;
	private bool restartMessageDisplayed;
	public float restartMessageDelay;
	private float restartMessageTime;

	// Use this for initialization
	void Start ()
	{
		PlayerController playerController;

		gameOver = false;
		humanPlayerWon = false;
		gameOverMessageDisplayed = false;
		restartMessageDisplayed = false;

		gameOverMessage.text = "";
		restartMessage.text = "";

		playerController = humanPlayer.GetComponent<PlayerController> ();
		humanPlayerName = playerController.playerName;

		playerController = computerPlayer.GetComponent<PlayerController> ();
		computerPlayerName = playerController.playerName;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameOver == true && gameOverMessageDisplayed == false)
		{
			if (humanPlayerWon == true)
			{
				gameOverMessage.text = "You Win";
				gameOverMessageDisplayed = true;
			}
			else
			{
				gameOverMessage.text = "Game Over";
				gameOverMessageDisplayed = true;
			}

			restartMessageTime = Time.time + restartMessageDelay;
		}
		else if (gameOver == true && restartMessageDisplayed == false && Time.time >= restartMessageTime)
		{
			restartMessage.text = "Press 'R' To Restart";
			restartMessageDisplayed = true;
		}
		else if (restartMessageDisplayed == true)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void PlayerBaseDestroyed (string player)
	{
		if (player == humanPlayerName)
		{
			Destroy (humanPlayer);
			gameOver = true;
			humanPlayerWon = false;
		}
		else if (player == computerPlayerName)
		{
			Destroy (computerPlayer);
			gameOver = true;
			humanPlayerWon = true;
		}
	}
}

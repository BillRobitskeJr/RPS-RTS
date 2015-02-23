using UnityEngine;
using System.Collections;

public class PlayerBaseController : MonoBehaviour
{
	public string player;
	public float maxHealth;
	private float currentHealth;

	private GameObject gameController;

	private Light hitFlash;
	private bool showHitFlash;

	// Use this for initialization
	void Start ()
	{
		PlayerController myPlayerController;

		myPlayerController = GetComponentInParent<PlayerController> ();
		player = myPlayerController.playerName;

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		hitFlash = GetComponent<Light> ();

		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentHealth <= 0.0f)
		{
			Destroy (this.gameObject);
			gameController.SendMessageUpwards ("PlayerBaseDestroyed", player);
		}

		if (showHitFlash)
		{
			hitFlash.enabled = true;
			showHitFlash = false;
		}
		else
		{
			hitFlash.enabled = false;
		}
	}

	public void TakeHit (float hitStrength)
	{
		currentHealth = currentHealth - hitStrength;
		hitFlash.intensity = (maxHealth - currentHealth) / maxHealth * 4;
		showHitFlash = true;
	}
}

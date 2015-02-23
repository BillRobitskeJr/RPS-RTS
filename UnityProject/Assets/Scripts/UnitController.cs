using UnityEngine;
using System.Collections;

// UnitController:  Controls the current state of the Unit

public class UnitController : MonoBehaviour
{
	public string unitType;
	public string player;
	public Color playerColor;

	public float maxHealth;
	private float currentHealth;
	private Material unitModelMaterial;

	private bool showHitFlash = false;
	private Light hitFlash;

	private Light selectionLight;

	void Start ()
	{
		Light[] childLights;

		currentHealth = maxHealth;

		unitModelMaterial = ((MeshRenderer)GetComponent<MeshRenderer>()).material;
		hitFlash = GetComponent<Light> ();
		childLights = GetComponentsInChildren<Light> ();
		foreach (Light light in childLights)
		{
			if (light.name == "SelectionLight")
			{
				selectionLight = light;
			}
		}
	}

	void Update ()
	{
		if (currentHealth <= 0)
		{
			Destroy (this.gameObject);
			return;
		}

		if (unitModelMaterial.color != playerColor)
		{
			unitModelMaterial.color = playerColor;
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
		hitFlash.intensity = (maxHealth - currentHealth) / maxHealth * 2;
		showHitFlash = true;
	}

	public void Select (bool select)
	{
		selectionLight.enabled = select;
	}
}
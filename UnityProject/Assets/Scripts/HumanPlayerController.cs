using UnityEngine;
using System.Collections;

public class HumanPlayerController : PlayerController {

	private GameObject selectedUnit;

	public float buildWaitTime;
	private float nextBuildTime;
	private Light buildReadyLight;

	// Use this for initialization
	protected override void Start () {
		Light[] lights;

		base.Start();

		lights = GetComponentsInChildren<Light> ();
		foreach (Light light in lights)
		{
			if (light.gameObject.name == "BuildReadyLight")
			{
				buildReadyLight = light;
			}
		}
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

		if (Time.time > nextBuildTime)
		{
			if (Input.GetKeyDown("1"))
			{
				SpawnUnit ("rock");
				nextBuildTime = Time.time + buildWaitTime;
			}
			else if (Input.GetKeyDown("2"))
			{
				SpawnUnit ("paper");
				nextBuildTime = Time.time + buildWaitTime;
			}
			else if (Input.GetKeyDown("3"))
			{
				SpawnUnit ("scissors");
				nextBuildTime = Time.time + buildWaitTime;
			}
		}
		if (Time.time > nextBuildTime)
		{
			if (buildReadyLight != null)
			{
				buildReadyLight.intensity = 4.0f;
			}
		}
		else
		{
			if (buildReadyLight != null)
			{
				buildReadyLight.intensity = (buildWaitTime - nextBuildTime + Time.time) / buildWaitTime * 2.0f;
			}
		}
	}

	protected override void FixedUpdate ()
	{
		Ray ray;
		RaycastHit hit;
		GameObject hitObject;
		UnitController hitUnitController;

		base.FixedUpdate ();

		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 50f))
			{
				if (hit.rigidbody != null)
				{
					hitObject = hit.rigidbody.gameObject;
					hitUnitController = hitObject.GetComponent<UnitController> ();
					if (hitUnitController != null)
					{
						if (hitUnitController.player == this.playerName)
						{
							if (hitObject == selectedUnit)
							{
								Debug.Log ("Deselect: " + hitUnitController.player + "'s " + hitUnitController.unitType);
								hitObject.SendMessage("Select", false, SendMessageOptions.DontRequireReceiver);
								selectedUnit = null;
							}
							else
							{
								Debug.Log ("Select: " + hitUnitController.player + "'s " + hitUnitController.unitType);
								if (selectedUnit != null)
								{
									selectedUnit.SendMessage("Select", false, SendMessageOptions.DontRequireReceiver);
								}
								hitObject.SendMessage("Select", true, SendMessageOptions.DontRequireReceiver);
								selectedUnit = hitObject;
							}
						}
					}
					else if (selectedUnit != null)
					{
						selectedUnit.SendMessage ("Follow", hitObject);
					}
				}
				else
				{
					if (selectedUnit != null)
					{
						selectedUnit.SendMessage ("MoveTo", hit.point);
					}
				}
			}
		}
	}
}

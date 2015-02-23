using UnityEngine;
using System.Collections;

public class UnitAttackController : MonoBehaviour {

	private UnitController myUnitController;

	public float attackStrength;
	public GameObject attackBeamPrefab;

	// Use this for initialization
	void Start () {
		myUnitController = GetComponentInParent<UnitController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay (Collider other)
	{
		UnitController otherUnitController;
		PlayerBaseController otherBaseController;
		GameObject attackBeam;
		
		if (other.tag == "Unit")
		{
			otherUnitController = other.GetComponentInParent<UnitController> ();
			
			if (otherUnitController.player != myUnitController.player)
			{
				if ((myUnitController.unitType == "rock" && otherUnitController.unitType == "scissors") ||
				    (myUnitController.unitType == "paper" && otherUnitController.unitType == "rock") ||
				    (myUnitController.unitType == "scissors" && otherUnitController.unitType == "paper"))
				{
					attackBeam = (GameObject)Instantiate (attackBeamPrefab, gameObject.transform.position, Quaternion.identity);
					attackBeam.SendMessage ("FireAt", other.gameObject.transform);
					other.gameObject.SendMessageUpwards("TakeHit", attackStrength * Time.deltaTime);
				}
			}
		}
		else if (other.tag == "PlayerBase")
		{
			otherBaseController = other.GetComponent<PlayerBaseController> ();

			if (otherBaseController.player != myUnitController.player)
			{
				attackBeam = (GameObject)Instantiate (attackBeamPrefab, gameObject.transform.position, Quaternion.identity);
				attackBeam.SendMessage ("FireAt", other.gameObject.transform);
				other.gameObject.SendMessageUpwards("TakeHit", attackStrength * Time.deltaTime);
			}
		}
	}
}

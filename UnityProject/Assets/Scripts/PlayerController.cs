using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Transform homeBase;
	public Transform enemyBase;
	public GameObject rockUnitPrefab;
	public GameObject paperUnitPrefab;
	public GameObject scissorsUnitPrefab;
	public Transform unitSpawn;

	public string playerName;
	public Color playerColor;

	// Use this for initialization
	protected virtual void Start () {

	}
	
	// Update is called once per frame
	protected virtual void Update () {

	}

	protected virtual void FixedUpdate ()
	{

	}

	protected void SpawnUnit(string unitType)
	{
		GameObject newUnit;
		GameObject unitPrefab;
		UnitController newUnitController;
		UnitMovementController newUnitMovementController;

		switch (unitType)
		{
		case "rock":
			unitPrefab = rockUnitPrefab;
			break;
		case "paper":
			unitPrefab = paperUnitPrefab;
			break;
		case "scissors":
			unitPrefab = scissorsUnitPrefab;
			break;
		default:
			unitPrefab = rockUnitPrefab;
			break;
		}
		newUnit = (GameObject)Instantiate(unitPrefab, unitSpawn.position, Quaternion.identity);
		
		newUnitController = newUnit.GetComponent<UnitController>();
		newUnitController.player = playerName;
		newUnitController.playerColor = playerColor;
		newUnitController.unitType = unitType;
		
		newUnitMovementController = newUnit.GetComponent<UnitMovementController>();
		newUnitMovementController.currentMoveTarget = enemyBase;
	}
}

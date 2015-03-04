using UnityEngine;
using System.Collections;

public class UnitMovementController : MonoBehaviour {

	private NavMeshAgent navAgent;
	public Transform currentMoveTarget;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentMoveTarget != null)
		{
			navAgent.destination = new Vector3(currentMoveTarget.position.x, 0.0f, currentMoveTarget.position.z);
		}
	}

	void MoveTo (Vector3 destination)
	{
		currentMoveTarget = null;
		navAgent.destination = new Vector3(destination.x, 0.0f, destination.z);
	}

	void Follow (GameObject target)
	{
		currentMoveTarget = target.transform;
	}
}

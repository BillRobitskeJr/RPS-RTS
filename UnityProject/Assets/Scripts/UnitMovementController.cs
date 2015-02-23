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
			navAgent.destination = currentMoveTarget.position;
		}
	}

	void MoveTo (Vector3 destination)
	{
		currentMoveTarget = null;
		navAgent.destination = destination;
	}

	void Follow (GameObject target)
	{
		currentMoveTarget = target.transform;
	}
}

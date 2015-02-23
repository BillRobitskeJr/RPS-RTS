using UnityEngine;
using System.Collections;

public class UnitAttackBeamController : MonoBehaviour {

	private Vector3 sourcePosition;
	private Vector3 targetPosition;

	private LineRenderer lineRenderer;
	private Light fireLight;
	private bool readyToFire = false;
	private bool hasFired = false;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		fireLight = GetComponent<Light> ();
		sourcePosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (hasFired)
		{
			lineRenderer.enabled = false;
			fireLight.enabled = true;
			Destroy (this.gameObject);
		}
		else if (readyToFire)
		{
			lineRenderer.SetPosition (0, sourcePosition);
			lineRenderer.SetPosition (1, targetPosition);
			lineRenderer.enabled = true;
			fireLight.enabled = true;
			hasFired = true;
		}
	}

	public void FireAt(Transform target)
	{
		targetPosition = target.position;
		readyToFire = true;
	}
}

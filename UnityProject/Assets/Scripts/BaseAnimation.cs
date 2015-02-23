using UnityEngine;
using System.Collections;

public class BaseAnimation : MonoBehaviour
{

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0.25f, 0.5f, 0.75f));
	}
}

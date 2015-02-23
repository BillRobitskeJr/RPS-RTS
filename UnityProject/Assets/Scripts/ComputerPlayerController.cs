using UnityEngine;
using System.Collections;

public class ComputerPlayerController : PlayerController {

	public float buildWaitTime;
	private float nextBuildTime;

	// Use this for initialization
	protected override void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		if (Time.time >= nextBuildTime)
		{
			switch (Random.Range(1, 4))
			{
			case 1:
				SpawnUnit ("rock");
				break;
			case 2:
				SpawnUnit ("paper");
				break;
			case 3:
				SpawnUnit ("scissors");
				break;
			}
			nextBuildTime = Time.time + buildWaitTime;
		}
	}
}

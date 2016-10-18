using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{

	private LevelManager levelManager;

	public int maxHits;

	private int timesHit;

	void Start () 
	{
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update () 
	{

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		timesHit++;
		SimulateWin();
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}

}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{

	private LevelManager levelManager;

	public Sprite[] hitSprites;

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

		// We use >= because: imagine you have some kind of game mechanic (like a powerup)
		// that makes timesHit go OVER max hits - your timesHit would never equal it!
		if (timesHit >= maxHits)
		{
			Destroy(gameObject);
		}
		else
		{
			LoadSprites ();
		}
	}

	void LoadSprites ()
	{
		/* First, set the spriteIndex value to 0. Second, call the sprite renderer and grab
		   the index value of the currently loaded sprite. Third, make it equal to the spriteIndex
		   within the hitSprites array. */
		int spriteIndex = 0;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		spriteIndex++;
	}

	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}

}

using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private LevelManager levelManager;
	private int timesHit;
	private int spriteIndex = 0;
	private bool isBreakable;

	void Start ()
	{
		isBreakable = (this.tag == "Breakable");

		timesHit = 0;

		if (isBreakable)
		{
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update ()
	{

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (isBreakable)
		{
			BrickHits();
		}
	}

	void BrickHits ()
	{
		timesHit++;

		int maxHits = hitSprites.Length + 1;

		// We use >= because: imagine you have some kind of game mechanic (like a powerup)
		// that makes timesHit go OVER max hits - your timesHit would never equal it
		if (timesHit >= maxHits)
		{
			breakableCount--;
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.7f);
			PuffSmoke();
			Destroy(gameObject);
			levelManager.BrickDestroyed();
		}
		else
		{
			LoadSprites ();
		}
	}

	void PuffSmoke ()
	{
		smoke.GetComponent<ParticleSystem> ().startColor = this.GetComponent<SpriteRenderer> ().color;
		Instantiate (smoke, transform.position, Quaternion.identity);
	}

	/* First, set the spriteIndex value to 0. Second, if sprite exists within the hitSprites array, call the sprite renderer and grab the index value of the currently loaded sprite. Third, make it equal to the spriteIndex within the hitSprites array. */
	void LoadSprites ()
	{
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

		spriteIndex++;
	}

}

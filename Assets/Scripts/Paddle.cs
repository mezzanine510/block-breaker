using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	void Start () 
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () 
	{
		if (autoPlay == false)
		{
			MoveWithMouse();
		}
		else
		{
			AutoPlay ();
		}
			
	}
	
	void AutoPlay ()
	{
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position; 
		paddlePosition.x = Mathf.Clamp(ballPosition.x, 0.5f, 15.5f);
		this.transform.position = paddlePosition;
	}

	void MoveWithMouse ()
	{
		// Create a local new Vector3 variable, which initially aligns to the left side 
		// of the screen, while keeping the current y-coord you started with
		Vector3 paddlePosition = new Vector3 (0.5f, this.transform.position.y, 0f);

		// Converts the mouse position from range 0-1.0, to a 16 block format
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		// Sets the x-coord of the Paddle to the position of the mouse, while limiting
		// its range to the edges of the screen  
		paddlePosition.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

		// Makes 'this' (Paddle object) position equal the vector 3 object's coordinates
		this.transform.position = paddlePosition;
	}

}

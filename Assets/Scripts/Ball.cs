﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{

	private Paddle paddle;

	private Vector3 paddleToBallVector;

	private bool hasStarted = false;

	void Start ()
	{
		paddle = GameObject.FindObjectOfType<Paddle>();
		// Get the distance between the paddle and ball by obtaining the difference in position
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update ()
	{
		// If that game hasn't started yet, lock the ball to the paddle.
		if (hasStarted == false)
		{
			// Set the position of the ball to the paddle's position + the offset
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		// If left mouse is clicked, declare the game has started and launch the ball.
		if (Input.GetMouseButtonDown(0) && hasStarted == false)
		{
			hasStarted = true;

			print ("Mouse clicked, launch ball");

			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D(Collision2D ballBounce)
	{
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		
		if (hasStarted == true)
		{
			GetComponent<AudioSource>().Play();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
			print (this.GetComponent<Rigidbody2D>().velocity);
		}
	}

}

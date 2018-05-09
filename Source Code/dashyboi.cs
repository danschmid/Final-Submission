using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashyboi : MonoBehaviour {

	public DashState dashState;
	public float dashTimer;
	public float maxDash = 10f;
	Rigidbody2D rigidbody;
	playercontroller player;
	public Vector2 savedVelocity;
	bool isDashKeyDown;

	void Start(){
		rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		player = gameObject.GetComponent<playercontroller> ();
	}

	void FixedUpdate () 
	{
		switch (dashState) 
		{
		case DashState.Ready:
			isDashKeyDown = Input.GetKeyDown (KeyCode.LeftShift);
			if(isDashKeyDown)
			{
				//savedVelocity = rigidbody.velocity;
				rigidbody.AddForce(new Vector2(6f, 0), ForceMode2D.Impulse);
				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			dashTimer += Time.deltaTime * 10;
			if(dashTimer >= maxDash || player.grounded || player.touchingWall)
			{
				dashTimer = maxDash;
				//rigidbody.velocity = savedVelocity;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
			}
			break;
		}
	}
}

public enum DashState 
{
	Ready,
	Dashing,
	Cooldown
}
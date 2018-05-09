using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envy_playercontroller : MonoBehaviour {



	//Load basic components of player
	public Rigidbody2D rb;
	public Animator myAnim;
	bool facingRight;

	//Movement variables
	public static float maxSpeed = 7f;

	//Jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.1f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public static float jumpHeight = 1f;

	//Wall-jumping variables
	bool touchingWall = false;
	float wallCheckRadius = 0.1f;
	public LayerMask wallLayer; //Should be same as groundlayer?
	public Transform wallCheck; //Will likely be (0,0,0)
	public static float wallJumpDist = 3.5f;
	public float wallJumpRate = 0.05f; //Larger number means larger delay 
	float nextWallJump = 0.0f;
	bool releasedSpacebar = false; //For making sure space was pressed again for a new wall jump

	//Shooting
	public Transform launch;
	public GameObject bubble;
	public static float fireRate = 0.25f; //Larger number means larger delay
	float nextFire = 0.0f;

	//Shooting powerup
	public static bool shootPowerupActive = false;
	float bulletSize = 1.0f;
	public float maxBulletSize = 10f;
	bool okayToFire = false; //To decide when to shoot the bullet

	//Coins
	public static int coinScore;

	//Initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();

		facingRight = true;
	}

	//Called each frame
	void FixedUpdate () 
	{
		//For debugging wall jumping
		//Debug.Log ("Grounded: ");
		//Debug.Log (grounded);
		//Debug.Log ("Wall: ");
		//Debug.Log (touchingWall);

		//Vertical movement
		//Vertical jumping. Check if we are grounded, if not then we are falling
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
		//Debug.Log (grounded);
		myAnim.SetBool ("isGrounded", grounded);
		//Require the player be grounded to jump
		if (grounded && Input.GetAxis ("Jump") > 0) {// && releasedSpacebar) {
			grounded = false;
			releasedSpacebar = false;
			myAnim.SetBool ("isGrounded", grounded);
			rb.AddForce (new Vector2 (0, jumpHeight), ForceMode2D.Impulse);
			Debug.Log ("Jumped!");
		}
		//Debug.Log (grounded);
		//Tell the animator how fast vertically we are going
		myAnim.SetFloat ("verticalSpeed", rb.velocity.y);

		//Wall jumping. Same idea as vertical jumping except with time delay from fireBubble
		touchingWall = Physics2D.OverlapBox(wallCheck.position, new Vector2 (0.1f,1.25f), 0f, wallLayer);
		//Debug.Log (touchingWall);
		//Debug.Log (wallJumpDist); //For debugging powerups
		//Make sure they aren't spamming wall-jump
		if (Time.time > nextWallJump && releasedSpacebar) {
			//Make sure they are touching a wall
			if (touchingWall && Input.GetAxis ("Jump") > 0) {
				touchingWall = false;
				releasedSpacebar = false;
				rb.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * wallJumpDist, wallJumpDist/1.2f), ForceMode2D.Impulse);
				nextWallJump = Time.time + wallJumpRate;
				//Debug.Log ("Wall jumped!");
			}
		}
		if (Input.GetAxis ("Jump") == 0) {
			releasedSpacebar = true;
		}
		//Debug.Log (releasedSpacebar);

		//Horizontal movement
		//Debug.Log (maxSpeed); 
		float move = Input.GetAxis("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));
		rb.velocity = new Vector2 (move*maxSpeed, rb.velocity.y);

		//For debugging movement
		//Debug.Log (rb.velocity);

		//Update whether we are facing right or not
		if (move>0&&!facingRight) {
			flip();
		} else if (move<0&&facingRight) {
			flip();
		}

		//Shooting
		if (Input.GetKeyDown (KeyCode.Mouse0) && !shootPowerupActive) {
			fireBubble ();
			okayToFire = false;

			//Growing bullet during powerup (holding shift down)
		} else if (Input.GetKey (KeyCode.Mouse0) && shootPowerupActive) {
			//Debug.Log ("Pressing shift!");
			okayToFire = true;
			bulletSize += 0.05f;
			if (bulletSize > maxBulletSize) {
				bulletSize = maxBulletSize;
			}
			Debug.Log (bulletSize);

			//Shooting bullet
		} else if (shootPowerupActive && okayToFire) {
			fireBubblePowerup ();
			okayToFire = false;
		}

	}







	void flip()
	{
		facingRight=!facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	//Shooting
	void fireBubble()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (facingRight) {
				Instantiate (bubble, launch.position, Quaternion.Euler (0, 0, 0));
			}
			else if (!facingRight) {
				Instantiate (bubble, launch.position, Quaternion.Euler (0, 0, 180f));
				//bubble.transform.Rotate(new Vector3(180f,0,0));
			}
		}
	}

	//Shooting with powerup
	void fireBubblePowerup()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (facingRight) {
				GameObject bullet = Instantiate (bubble, launch.position, Quaternion.Euler (0, 0, 0));
				float currentScaleX = bullet.transform.localScale.x;
				float currentScaleY = bullet.transform.localScale.y;
				bullet.transform.localScale = new Vector2 (bulletSize*currentScaleX, bulletSize*currentScaleY);
			}
			else if (!facingRight) {
				GameObject bullet = Instantiate (bubble, launch.position, Quaternion.Euler (0, 0, 180f));
				float currentScaleX = bullet.transform.localScale.x;
				float currentScaleY = bullet.transform.localScale.y;
				bullet.transform.localScale = new Vector2 (bulletSize*currentScaleX, bulletSize*currentScaleY);
			}
		}

		bulletSize = 1.0f;
	}
}
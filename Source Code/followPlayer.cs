using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public bool CatchType = false;

	GameObject player;
	Rigidbody2D body;

    private Transform otherEntity;
    public float distScale;
    private Transform thisEntity;
    // Use this for initialization
    void Start () {
		player = GameObject.Find("Player");
		body = GetComponent<Rigidbody2D>();
        
    }

	// Update is called once per frame
	void Update () {
		if (CatchType) CatchUpdate();
	}

    private void CatchUpdate()
	{
        //Vector2 temp = (Vector2)Demon.transform.position - (Vector2)gameObject.transform.position;
        //if (temp.magnitude > ((Vector2)distance).magnitude) gameObject.transform.position += distance;
        //else gameObject.transform.position = Demon.transform.position;

        //Vector3 distance = (Demon.transform.position - gameObject.transform.position);

        //if (distance.y > 0) body.velocity = new Vector2(body.velocity.x, AngleSpeed);
        //else if (distance.y < 0) body.velocity = new Vector2(body.velocity.x, -1 * AngleSpeed);
        //else body.velocity = new Vector2(body.velocity.x, 0);

        //if (distance.x > 0) body.velocity = new Vector2(AngleSpeed, body.velocity.y);
        //else if (distance.x < 0) body.velocity = new Vector2(-1 * AngleSpeed, body.velocity.y);
        //else body.velocity = new Vector2(0, body.velocity.y);


        if (Time.timeScale == 2f);
            gameObject.transform.position += (player.transform.position - gameObject.transform.position) / (150+distScale);
    }
}

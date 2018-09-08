using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

	private Rigidbody player;
	private float dashTime;
	public float startDashTime;
	public float dashSpeed;
	private float xTrans;
	private int direction;
	private bool canDash;

	void Start () {
		player = GetComponent<Rigidbody> ();
		dashTime = startDashTime;
		canDash = false;
		player.constraints = RigidbodyConstraints.FreezeRotationY;
		player.constraints = RigidbodyConstraints.FreezePositionZ;
	}
	
	// is player inside of dash-sphere?
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("dashSphere"))
		{
			Debug.Log ("Colliding");
			canDash = true;
		}
	}

	// has player left dash-sphere?
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("dashSphere"))
		{
			Debug.Log("Left collider");
			canDash = false;
		}
	}

	void FixedUpdate () {

		// actual dash move
		if (direction == 0 && canDash == true)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				direction = 1;
			}
		}
		else
		{
			if (dashTime <= 0)
			{
				direction = 0;
				dashTime = startDashTime;
			}
			else
			{
				dashTime -= Time.deltaTime;
				if (direction == 1)
				{
					player.velocity = Vector2.up * dashSpeed;
				}
			}
		}

		// left-right movement
		xTrans = Input.GetAxis ("Horizontal") * Time.deltaTime * 15.0f;
		transform.Translate (xTrans, 0, 0);
	}
}

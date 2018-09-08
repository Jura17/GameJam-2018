using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

	public Material[] material;

	private Rigidbody2D player;
	private float dashTime;
	public float startDashTime;
	public float dashSpeed;
	private float xTrans;
	public static bool dashing;
	private bool canDash;

	void Start () {
		player = GetComponent<Rigidbody2D> ();
		dashTime = startDashTime;
		canDash = false;
	}

	// is player inside of dash-sphere?
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("dashSphere"))
		{
			canDash = true;
			other.gameObject.GetComponent<Renderer>().material = material[1];
			Debug.Log("Can dash: " + canDash);
		}

		if (other.gameObject.CompareTag("smallSphere"))
		{
			canDash = true;
			//dashSpeed = dashSpeed + (dashSpeed * 0.5f);
			other.gameObject.GetComponent<Renderer>().material = material[3];
			Debug.Log("Can dash: " + canDash);
		}
	}

	// is player inside of dash-sphere?
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("dashSphere"))
		{
			canDash = true;
			other.gameObject.GetComponent<Renderer>().material = material[1];
			Debug.Log("Can dash: " + canDash);
		}

		if (other.gameObject.CompareTag("smallSphere"))
		{
			canDash = true;
			//dashSpeed = dashSpeed + (dashSpeed * 0.5f);
			other.gameObject.GetComponent<Renderer>().material = material[3];
			Debug.Log("Can dash: " + canDash);
		}
	}

	// has player left dash-sphere?
	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("dashSphere"))
		{
			canDash = false;
			other.gameObject.GetComponent<Renderer>().material = material[0];
			Debug.Log("Can dash: " + canDash);
		}

		if (other.gameObject.CompareTag("smallSphere"))
		{
			other.gameObject.GetComponent<Renderer>().material = material[2];
			//dashSpeed = dashSpeed - (dashSpeed*0.5f);
		}
	}

	void Update () {

		// actual dash move
		if (dashing == false && canDash == true)
		{
			if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.RightControl))
			{
				dashing = true;
			}
		}
		else
		{
			if (dashTime <= 0)
			{
				dashing = false;
				dashTime = startDashTime;
			}
			else
			{
				dashTime -= Time.deltaTime;
				if (dashing==true)
				{
					player.velocity = Vector2.up * dashSpeed;
					PlayerController.numOfJumps = 2;
				}
			}
		}
	}
}

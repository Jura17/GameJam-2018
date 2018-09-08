using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSphere_ChangeColor : MonoBehaviour {

	public static Material[] material;
	public static Renderer rend;

	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	
	public void OnTriggerEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			rend.sharedMaterial = material[1];
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour 
{
	public float health = 3;
	Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}

	void GetDamage(int d)
	{
		health -= d;
		if(health <= 0)
		{
			rb.isKinematic = false;
		}

	}
	

}

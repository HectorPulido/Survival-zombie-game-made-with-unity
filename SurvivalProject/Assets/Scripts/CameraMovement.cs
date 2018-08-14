using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{
	Transform player;
	Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		offset = transform.position - player.position;	
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		transform.position = offset + player.position;
	}
}

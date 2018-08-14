using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed;
	public float angularSpeed;
	public float attackFrequency;

	Rigidbody rb;
	Animator anim;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();	
		anim = GetComponent<Animator>();


		anim.applyRootMotion = false;
	}
	
	float h, v, count;
	// Update is called once per frame
	void Update () 
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
			return;

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");		

		transform.Rotate(0,h * angularSpeed * Time.deltaTime,0, Space.Self);
		anim.SetFloat("Forward", v);

		count += Time.deltaTime;
		//Debug.DrawRay(transform.position + Vector3.up, transform.forward * 1);
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(count > attackFrequency)
			{
				count = 0;
				anim.SetTrigger("Attack");
				RaycastHit rh;
				if(Physics.Raycast(transform.position + Vector3.up*1.5f, transform.forward, out rh, 1f))
				{
					if(rh.collider != null)
					{
						rh.collider.SendMessage("GetDamage", 1, SendMessageOptions.DontRequireReceiver);
					}
				}

			}
		}

	}
	void FixedUpdate()
	{
		var temp = transform.forward * v * speed;
		rb.velocity = new Vector3(temp.x, rb.velocity.y, temp.z);
	}
}

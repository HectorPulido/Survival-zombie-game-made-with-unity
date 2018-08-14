using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour 
{
	public enum States { patrol, attack}

	public States state;
	public float attackFrequency;
	public float attackRange;
	public float patrolFrequency;
	public float patrolRange;

	Transform player;
	NavMeshAgent agent;
	Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	float cont;
	void Update () 
	{
		var dist = Vector3.Distance(transform.position, player.position);
		cont += Time.deltaTime;
		anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
		if(state == States.attack)
		{			
			agent.speed = 2;

			agent.SetDestination(player.position);	
			if(dist <= attackRange)
			{
				if(cont > attackFrequency)
				{
					cont = 0;
					transform.LookAt(player);
					anim.SetTrigger("Attack");
				}
			}
			if(dist > patrolRange * 1.2f)
			{
				state = States.patrol;
			}			
		}
		else if (state == States.patrol)
		{
			agent.speed = 1;
			if(dist <= patrolRange)
			{
				state = States.attack;
			}
			else
			{
				if(cont > patrolFrequency)
				{
					cont = 0;
					agent.SetDestination(Random.insideUnitSphere * patrolRange 
					+ transform.position);	
				}
			}
		}


	}
}

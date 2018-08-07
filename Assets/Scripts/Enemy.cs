using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private float speed = 0f;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		rigidbody.velocity = new Vector2(speed, 0);

		if (IsFacingRight())
			rigidbody.velocity = new Vector2(speed, 0f);
		else
			rigidbody.velocity = new Vector2(-speed, 0f);
	}

	bool IsFacingRight()
	{
		return transform.localScale.x > 0;
	}

	void onTriggerExit2D()
	{
		Debug.Log("work");
		transform.localScale = new Vector2(- (Mathf.Sign(rigidbody.velocity.x)), 1f);
	}

}

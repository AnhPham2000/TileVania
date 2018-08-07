using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Animator ani;
	private Rigidbody2D rigidbody;
	private CapsuleCollider2D bodyCol;
	private BoxCollider2D feetCol;
	private float speed = 5f;
	private float jumpHeight = 15f;
	private float initialGravity;
	private bool isAlive;

	void Awake()
	{
		feetCol = GetComponent<BoxCollider2D>();
		bodyCol = GetComponent<CapsuleCollider2D>();
		ani = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () 
	{
		isAlive = true;
		initialGravity = rigidbody.gravityScale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isAlive)
			return;
		Run();
		Jump();
		Climb();
		Flip();
		Die();
	}

	void Run()
	{
		Vector2 playervelocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody.velocity.y);
		rigidbody.velocity = playervelocity;
		bool HasSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
		ani.SetBool("IsRunning", HasSpeed);
	}

	void Jump()
	{
		if (!feetCol.IsTouchingLayers(LayerMask.GetMask("Ground")))
		return;

		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector2 jumpVelocity = new Vector2(0f, jumpHeight);
			rigidbody.velocity += jumpVelocity;
		}

	}

	void Climb()
	{
		if (!feetCol.IsTouchingLayers(LayerMask.GetMask("Climbing")))
		{
			ani.SetBool("IsClimbing", false);
			rigidbody.gravityScale = initialGravity;
			return;
		}

		Vector2 climbVerlocity = new Vector2 (rigidbody.velocity.x, Input.GetAxis("Vertical") * (speed + 4f));
		rigidbody.velocity = climbVerlocity;
		rigidbody.gravityScale = 0;

		bool HasSpeed = Mathf.Abs(rigidbody.velocity.y) > Mathf.Epsilon;
		ani.SetBool("IsClimbing", HasSpeed);
	}

	void Flip()
	{
		bool HasSpeed = Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon;
		if (HasSpeed)
		{
			transform.transform.localScale = new Vector2 (Mathf.Sign(rigidbody.velocity.x), 1f);
		}
	}

	void Die()
	{
		if (feetCol.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazard")))
		{
			isAlive = false;
			ani.SetTrigger("Die");
			rigidbody.velocity = Vector3.zero;
			GameSession.Instance.DeathEvent();
		}
	}

}

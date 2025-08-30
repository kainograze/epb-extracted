// d4e5115e396b84ea8820f5b0a8f12827, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// FPSWalker
using System;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterController))]
public class FPSWalker : MonoBehaviour
{
	public float speed;

	public float jumpSpeed;

	public float gravity;

	private Vector3 moveDirection;

	private bool grounded;

	public FPSWalker()
	{
		speed = 6f;
		jumpSpeed = 8f;
		gravity = 20f;
		moveDirection = Vector3.zero;
		grounded = false;
	}

	public void FixedUpdate()
	{
		if (grounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		CollisionFlags collisionFlags = characterController.Move(moveDirection * Time.deltaTime);
		grounded = checked((int)(collisionFlags & CollisionFlags.Below)) != 0;
	}

	public void Main()
	{
	}
}

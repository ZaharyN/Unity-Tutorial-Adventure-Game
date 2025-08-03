using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Input Actions")]
	[SerializeField] private InputAction moveAction;

	[Header("Character speed")]
	[SerializeField] private float movementSpeed = 3f;

	private Rigidbody2D rigidBody2D;
	Vector2 move;

	private void Start()
	{
		moveAction.Enable();
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		move = moveAction.ReadValue<Vector2>();
	}

	private void FixedUpdate()
	{
		Vector2 position = rigidBody2D.position + movementSpeed * Time.deltaTime * move;
		rigidBody2D.MovePosition(position);
	}
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Input Actions")]
	[SerializeField] private InputAction moveAction;

	[Header("Character properties")]
	[SerializeField] private float movementSpeed = 3f;
	[SerializeField] private int maxHealth = 5;

	private Rigidbody2D rigidBody2D;
	private Vector2 move;
	private int currentHealth;

	private void Start()
	{
		moveAction.Enable();
		rigidBody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
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

	public void ChangeHealth(int amount)
	{
		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		Debug.Log(currentHealth + "/" + maxHealth);
	}
}

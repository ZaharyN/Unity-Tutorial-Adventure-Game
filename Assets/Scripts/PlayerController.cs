using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Input Actions")]
	[SerializeField] private InputAction moveAction;

	[Header("Character properties")]
	[SerializeField] private float movementSpeed = 3.0f;
	[SerializeField] private int maxHealth = 5;

	[Header("Character invincibility")]
	[SerializeField] private float timeInvincible = 2.0f;

	private Rigidbody2D rigidBody2D;
	private Vector2 move;
	private int currentHealth;
	private bool isInvincible;
	private float damageCooldown;

	public int CurrentHealth { get { return currentHealth; } }
	public int MaxHealth { get { return maxHealth; } }

	private void Start()
	{
		moveAction.Enable();
		rigidBody2D = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
	}

	void Update()
	{
		move = moveAction.ReadValue<Vector2>();

		if (isInvincible)
		{
			damageCooldown -= Time.deltaTime;

			if (damageCooldown < 0)
			{
				isInvincible = false;
			}
		}
	}

	private void FixedUpdate()
	{
		Vector2 position = rigidBody2D.position + movementSpeed * Time.deltaTime * move;
		rigidBody2D.MovePosition(position);
	}

	public void ChangeHealth(int amount)
	{
		if (amount < 0)
		{
			if (isInvincible)
			{
				return;
			}
			isInvincible = true;
			damageCooldown = timeInvincible;
		}

		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		Debug.Log(currentHealth + "/" + maxHealth);
	}
}

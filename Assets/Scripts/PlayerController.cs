using Unity.VisualScripting;
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
	private Animator animator;
	private Vector2 moveDirection = new Vector2(1, 0);
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
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
	}

	void Update()
	{
		move = moveAction.ReadValue<Vector2>();

		if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
		{
			moveDirection.Set(move.x, move.y);
			moveDirection.Normalize();
		}
		
		animator.SetFloat("Look X", moveDirection.x);
		animator.SetFloat("Look Y", moveDirection.y);
		animator.SetFloat("Speed", move.magnitude);
		
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
			animator.SetTrigger("Hit");
			if (isInvincible)
			{
				return;
			}
			isInvincible = true;
			damageCooldown = timeInvincible;
		}

		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		UIHandler.Instance.SetHealthValue(CurrentHealth / (float)maxHealth);
	}
}

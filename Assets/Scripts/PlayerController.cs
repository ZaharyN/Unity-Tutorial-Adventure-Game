using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Input Actions")]
	[SerializeField] private InputAction moveAction;

	[Header("Character speed")]
	[SerializeField] private float movementSpeed = 3f;

	private void Start()
	{
		moveAction.Enable();
	}

	void Update()
	{
		Vector2 move = moveAction.ReadValue<Vector2>();

		Vector2 position = (Vector2)transform.position + Time.deltaTime * move * movementSpeed;
		transform.position = position;
	}
}

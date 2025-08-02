using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction moveAction;

    [Header("Character speed")]
    [SerializeField] private float horizontalSpeed = default;
    [SerializeField] private float verticalSpeed = default;

	private void Start()
	{
        moveAction.Enable();
	}

	// Update is called once per frame
	void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        Vector2 position = (Vector2)transform.position + move*0.1f;
        transform.position = position;
    }
}

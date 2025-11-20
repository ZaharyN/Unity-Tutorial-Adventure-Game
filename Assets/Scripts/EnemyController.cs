using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Character properties")]
    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private bool isVertical;
    [SerializeField] private float reverseMovementTimer = 5.0f;

    private Rigidbody2D rigidBody2D;
    private int direction = 1;
    private float currentMovementTimer = 0.0f;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        currentMovementTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentMovementTimer += Time.deltaTime;

        if (currentMovementTimer >= reverseMovementTimer)
        {
            direction *= -1;
            currentMovementTimer = 0.0f;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidBody2D.position;

        if (isVertical)
        {
            position.y += Time.deltaTime * movementSpeed * direction;
        }
        else
        {
            position.x += Time.deltaTime * movementSpeed * direction;
        }

        rigidBody2D.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}

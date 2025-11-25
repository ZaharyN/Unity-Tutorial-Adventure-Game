using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Character properties")]
    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private bool isVertical;
    [SerializeField] private float reverseMovementTimer = 5.0f;
    [SerializeField] private ParticleSystem smokeEffect = default;
    
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private AudioSource audioSource;
    private int direction = 1;
    private float currentMovementTimer = 0.0f;
    private bool isBroken = true;
    
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
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
        if(!isBroken) return;
        
        Vector2 position = rigidBody2D.position;

        if (isVertical)
        {
            position.y += Time.deltaTime * movementSpeed * direction;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x += Time.deltaTime * movementSpeed * direction;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
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

	void OnCollisionEnter2D(Collision2D collision)
	{
        Destroy(gameObject);
	}
	
	public void Fix()
    {
        animator.SetTrigger("IsFixed");
        audioSource.Stop();
        smokeEffect.Stop();
        
    	isBroken = false;
    	rigidBody2D.simulated = false;
    }
}

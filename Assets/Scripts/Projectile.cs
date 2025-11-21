using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Launch(Vector2 direction, float force)
    {
    	rigidBody2D.AddForce(direction * force);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Projectile colllides with: " + collision.gameObject);
		Destroy(this.gameObject);
	}
}

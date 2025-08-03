using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
	[SerializeField] private int healthIncrease = 1;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerController playerController = collision.GetComponent<PlayerController>();
		if (playerController != null)
		{
			playerController.ChangeHealth(healthIncrease);
			Destroy(this.gameObject);
		}
	}
}

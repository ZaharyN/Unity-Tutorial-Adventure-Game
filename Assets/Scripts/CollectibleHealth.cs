using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
	[SerializeField] private int healthIncrease = 1;
	[SerializeField] private AudioClip collectedClip = default;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerController playerController = collision.GetComponent<PlayerController>();
		if (playerController != null)
		{
			if (playerController.CurrentHealth < playerController.MaxHealth)
			{
				playerController.ChangeHealth(healthIncrease);
				playerController.PlaySound(collectedClip);
				Destroy(this.gameObject);
			}
		}
	}
}

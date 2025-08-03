using Unity.VisualScripting;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
	[SerializeField] private int damageTaken = 1;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		PlayerController controller = collision.GetComponent<PlayerController>();

		if (controller != null)
		{
			if (controller.CurrentHealth > 0)
			{
				controller.ChangeHealth(-damageTaken);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		PlayerController controller = collision.GetComponent<PlayerController>();

		if (controller != null)
		{
			if (controller.CurrentHealth > 0)
			{
				controller.ChangeHealth(-damageTaken);
			}
		}
	}
}

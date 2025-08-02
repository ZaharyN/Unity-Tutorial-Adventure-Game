using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = default;
    [SerializeField] private float verticalSpeed = default;

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0.0f;
        float vertical = 0.0f;

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizontal = -1.0f;
        }
        else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizontal = 1.0f; 
        }

        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            vertical = 1.0f;
        }
        else if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            vertical = -1.0f;   
        }

        Vector2 position = transform.position;

        position.x += 0.1f * horizontal;
        position.y += 0.1f * vertical;

        transform.position = position;
    }
}

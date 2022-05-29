using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private MovementScript _movementScript;

    private void Start()
    {
        _movementScript = GetComponent<MovementScript>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            _movementScript.Move(Keyboard.current.wKey.isPressed);
        }
        else
        {
            _movementScript.velocity = 0f;
        }
    }
}
using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameManagerScript _gameManager;
    private MovementScript _movementScript;
    private Rigidbody2D _rb;

    private void Start()
    {
        _movementScript = GetComponent<MovementScript>();
        _gameManager = FindObjectOfType<GameManagerScript>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_gameManager.ballInstance.gameObject.activeInHierarchy)
        {
            var ballRb = _gameManager.ballInstance.GetComponent<Rigidbody2D>();

            if (Math.Abs(_rb.position.y - ballRb.position.y) > 1)
            {
                _movementScript
                    .Move(_rb.position.y < ballRb.position.y);
            }
        }
    }
}
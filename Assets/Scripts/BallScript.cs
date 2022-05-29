using System;
using UnityEngine;
using Random = System.Random;

public class BallScript : MonoBehaviour
{
    private GameManagerScript _gameManagerScript;
    private Rigidbody2D _rb;

    private void Start()
    {
        _gameManagerScript = FindObjectOfType<GameManagerScript>();
        _rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(ShootRandomDirection), 2f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _rb.AddForce(new Vector2(0,
                other.collider.GetComponent<MovementScript>().velocity * 3));
        }
        else if (other.collider.CompareTag("ScoreWall"))
        {
            _gameManagerScript.Restart();
        }
    }

    private void ShootRandomDirection()
    {
        var randomNumber = new Random().NextDouble();
        GetComponent<Rigidbody2D>().AddForce(randomNumber <= 0.5 ? new Vector2(100, 10) : new Vector2(-100, 10));
    }
}
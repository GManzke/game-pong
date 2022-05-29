using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 8f;
    public float velocity;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(bool isUp)
    {
        velocity = (isUp ? speed : -speed);
        rb.transform.position += new Vector3(0, velocity * Time.deltaTime, 0);
    }
}
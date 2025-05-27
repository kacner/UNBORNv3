using UnityEngine;

public class move : MonoBehaviour
{
    public float movespeed = 0.1f;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + movespeed, transform.position.y);
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Destroy(gameObject);
        }
    }
}

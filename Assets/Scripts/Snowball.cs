using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float lifeTime = 10f;

    private Vector2 moveDirection;

    private void Start()
    {
        moveDirection = GetRandomDirection();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private Vector2 GetRandomDirection()
    {
        Vector2[] directions =
        {
            Vector2.up,
            Vector2.down,
            Vector2.left,
            Vector2.right,
            new Vector2(1,1).normalized,
            new Vector2(-1,1).normalized,
            new Vector2(1,-1).normalized,
            new Vector2(-1,-1).normalized
        };

        return directions[Random.Range(0, directions.Length)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
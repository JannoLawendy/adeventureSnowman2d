using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float bulletLifetime = 10f;

    private Transform purly;

    void Start()
    {
        GameObject purlyObject = GameObject.Find("Purly");

        if (purlyObject != null)
        {
            purly = purlyObject.transform;
        }

        Destroy(gameObject, bulletLifetime);
    }

    void Update()
    {
        if (purly == null) return;

        Vector2 direction = (purly.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Purly")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("LandingScene");
        }
    }
}
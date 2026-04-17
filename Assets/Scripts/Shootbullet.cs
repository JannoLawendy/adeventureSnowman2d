using UnityEngine;

public class shootBullet : MonoBehaviour
{
    [Header("Cannon Parameters")]
    [SerializeField] private float bulletSpeed = 8f;
    [SerializeField] private float shootInterval = 20f;

    [Header("Object References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody2D bulletPrefab;

    private Transform purly;

    void Start()
    {
        GameObject purlyObject = GameObject.Find("Purly");

        if (purlyObject != null)
        {
            purly = purlyObject.transform;
        }

        InvokeRepeating(nameof(HandleShooting), 1f, shootInterval);
    }

    private void HandleShooting()
    {
        if (purly == null || bulletSpawn == null || bulletPrefab == null) return;

        Debug.Log("Snowgun fired");

        Rigidbody2D bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            Quaternion.identity
        );

        Vector2 direction = (purly.position - bulletSpawn.position).normalized;
        bullet.linearVelocity = direction * bulletSpeed;
    }
}
using UnityEngine;

public class SnowGun : MonoBehaviour
{
    [SerializeField] private GameObject snowballPrefab;
    [SerializeField] private Transform firePoint;

    public void Fire()
    {
        Instantiate(snowballPrefab, firePoint.position, firePoint.rotation);
    }
}
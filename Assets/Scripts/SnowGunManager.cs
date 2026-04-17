using System.Collections;
using UnityEngine;

public class SnowGunManager : MonoBehaviour
{
    [SerializeField] private SnowGun gun1;
    [SerializeField] private SnowGun gun2;
    [SerializeField] private float fireGap = 20f;

    private void Start()
    {
        StartCoroutine(FireGunsAlternately());
    }

    private IEnumerator FireGunsAlternately()
    {
        while (true)
        {
            gun1.Fire();
            yield return new WaitForSeconds(fireGap);

            gun2.Fire();
            yield return new WaitForSeconds(fireGap);
        }
    }
}
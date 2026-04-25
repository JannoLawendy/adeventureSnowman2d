using UnityEngine;

public class WallBalloonRespawn : MonoBehaviour
{
    public GameObject balloonPrefab;

    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnTop;
    public Transform spawnBottom;

    private void Start()
    {
        SpawnBalloon();
    }

    void SpawnBalloon()
    {
        Transform chosenSpawn;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                chosenSpawn = spawnLeft;
                break;
            case 1:
                chosenSpawn = spawnRight;
                break;
            case 2:
                chosenSpawn = spawnTop;
                break;
            default:
                chosenSpawn = spawnBottom;
                break;
        }

        GameObject balloon = Instantiate(balloonPrefab, chosenSpawn.position, Quaternion.identity);

        Balloon b = balloon.GetComponent<Balloon>();
        if (b != null)
        {
            b.spawner = this;
        }
    }

    public void BalloonPopped()
    {
        Invoke(nameof(SpawnBalloon), 2f);
    }
}
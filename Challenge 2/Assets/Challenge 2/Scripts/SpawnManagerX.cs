using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public static SpawnManagerX Instance { get; private set; }
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    public float minDelay = 1f;
    public float maxDelay = 5f;

    private bool isSpawnig;

    private void Awake()
    {
        isSpawnig = false;
    }

    private void Update()
    {
        if (!isSpawnig)
        {
            float timer = Random.Range(minDelay, maxDelay);
            Invoke(nameof(SpawnRandomBall), timer);
            isSpawnig = true;
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        int ballIndex = Random.Range(0, 3);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        isSpawnig = false;
    }



















}

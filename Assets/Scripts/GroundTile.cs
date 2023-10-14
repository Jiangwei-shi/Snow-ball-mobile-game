using UnityEngine;

public class GroundTile : MonoBehaviour
{

    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        //SpawnObstacle();
        SpawnCoins();
        SpawnSnowflakes();
        //SpawnTrees();
        SpawnFire();
        SpawnObstacleTree();
    }
    
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstacle at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins ()
    {
        int coinsToSpawn = 10;
        for (var i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint(point)) 
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

    Vector3 GetRandomZaixsPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            collider.bounds.max.x,
            collider.bounds.max.y,
            collider.bounds.max.z
        );

        if (point != collider.ClosestPoint(point)) 
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

    public GameObject snowFlake;

    void SpawnSnowflakes ()
    {
        int snowFlakeToSpawan = 1;
        for (var i = 0; i < snowFlakeToSpawan; i++)
        {
            GameObject temp = Instantiate(snowFlake);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    // public GameObject tree;

    // void SpawnTrees ()
    // {
    //     int treeToSpawn = 2;
    //     for (var i = 0; i < treeToSpawn; i++)
    //     {
    //         GameObject temp = Instantiate(tree);
    //         temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    //     }
    // }

    public GameObject fire;

    void SpawnFire ()
    {
        int fireToSpawn = 2;
        for (var i = 0; i < fireToSpawn; i++)
        {
            GameObject temp = Instantiate(fire);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    public GameObject obstacle_tree;

    void SpawnObstacleTree() 
    {
       int num = Random.Range(0, 5);
       int obstacleTreeToSpawn = 0;
       if (num == 0)
       {
           obstacleTreeToSpawn = 1;
       } else 
       {
           obstacleTreeToSpawn = 0;
       }

       for (var i = 0; i < obstacleTreeToSpawn; i++)
       {
           GameObject temp = Instantiate(obstacle_tree);
           temp.transform.position = GetRandomZaixsPointInCollider(GetComponent<Collider>());
       }
    }
}

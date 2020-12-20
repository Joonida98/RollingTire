using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager2 : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float spawnZ = 0.0f;
    public float tileLength = 30; // 타일 크기
    public int numberOfTiles = 7; //새로 생기는 타일의 개수
    private List<GameObject> activeTiles = new List<GameObject>();
    public float DestroyTime; // * 값이 80이면 Z축 1680까지 타일을 생성함 




    public Transform playerTransform;
    void Start()
    {
        Destroy(gameObject, DestroyTime);

        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > spawnZ - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(go);
        spawnZ += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

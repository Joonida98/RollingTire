using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform PlayerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 10.0f; // 타일 크기
    private int amnTilesOnScreen = 3; //새로 생기는 타일의 개수
    // Start is called before the first frame update
    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
       
        for(int i =0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }
}

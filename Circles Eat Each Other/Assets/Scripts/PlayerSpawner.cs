using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        SpawnPlayer();
        Destroy(gameObject);
    }
    
    private void SpawnPlayer()
    {
        float x = Random.Range(0, 5772);
        float y = Random.Range(0, 4906);
        Vector3 spawnPosition = new Vector3(x, y, 1);
        Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Random = UnityEngine.Random;

public class FoodFactory : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;

    private float x, y;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        for (;;)
        {
            x = Random.Range(0, Map.XLimit);
            y = Random.Range(0, Map.YLimit);
            Instantiate(foodPrefab, new Vector3(x, y, 1), Quaternion.identity);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
}
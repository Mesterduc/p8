using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float MaxTras;
    private float spawnTime;

    void Start()
    {
        StartCoroutine(FoodSpawn());
    }

    IEnumerator FoodSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, MaxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject foodObj = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], position, Quaternion.identity);
            spawnTime = Time.time;
            yield return new WaitForSeconds(secondSpawn);
        }
    }

  

}
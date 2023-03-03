using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefab; // Drag and drop enemy prefab here in Inspector
    public float generationInterval = 5.0f; // Time in seconds between enemy generation

    private Vector3 previousPosition;
    private float timer;

    void Start()
    {
        previousPosition = transform.position;
        timer = generationInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(enemyPrefab, previousPosition, Quaternion.identity).transform.localScale = new Vector3(110f, 110f, 110f);
            previousPosition = transform.position;
            timer = generationInterval;
        }
    }
}

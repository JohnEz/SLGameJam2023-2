using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private float SPAWN_PERIOD = 5.0f;
    [SerializeField] private GameObject spawnPrefab;

    [SerializeField] private GameObject wallPrefab;

    private float cooldown;

    private void Start() {
        cooldown = SPAWN_PERIOD;
    }

    private void Update() {
        cooldown -= Time.deltaTime;
        if (cooldown > 0) return;
        cooldown = SPAWN_PERIOD;

        var spawnPos = transform.position;
        const float width = 5.5f; // tuck in boys
        spawnPos.x = Random.Range(-width, width);

        GameObject newAI = Instantiate(spawnPrefab);

        newAI.transform.position = spawnPos;
    }
}
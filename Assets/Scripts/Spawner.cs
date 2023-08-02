using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] private float SPAWN_PERIOD = 1.0f;
    [SerializeField] private GameObject spawnPrefab;

    [SerializeField] private float WALL_SPAWN_PERIOD = 6.0f;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject warningPrefab;

    [SerializeField] private float WARNING_TIME = 2.0f;

    private GameObject currentWarningGo;

    private float cooldown;
    private float wallCooldown;

    private void Start() {
        cooldown = SPAWN_PERIOD;
        wallCooldown = WALL_SPAWN_PERIOD;
    }

    private void Update() {
        SpawnUpdate();

        SpawnWallUpdate();
    }

    private void SpawnUpdate() {
        cooldown -= Time.deltaTime;
        if (cooldown > 0) return;
        cooldown = SPAWN_PERIOD;

        var spawnPos = transform.position;
        const float width = 5.5f; // tuck in boys
        spawnPos.x = Random.Range(-width, width);

        GameObject newAI = Instantiate(spawnPrefab);

        newAI.transform.position = spawnPos;
    }

    private void SpawnWallUpdate() {
        wallCooldown -= Time.deltaTime;
        if (wallCooldown > 0) return;
        wallCooldown = WALL_SPAWN_PERIOD;

        StartCoroutine(WallSpawnEnumerator());
    }

    private IEnumerator WallSpawnEnumerator() {
        bool isLeft = Random.value >= 0.5;

        SpawnWarning(isLeft);

        yield return new WaitForSeconds(WARNING_TIME);

        Destroy(currentWarningGo);

        SpawnWall(isLeft);
    }

    private void SpawnWarning(bool isLeft) {
        if (currentWarningGo) {
            Destroy(currentWarningGo);
        }

        Vector3 warningPos = new Vector3(isLeft ? -2.5f : 2.5f, -8, transform.position.z);

        GameObject newWarning = Instantiate(warningPrefab);
        newWarning.transform.position = warningPos;

        currentWarningGo = newWarning;
    }

    private void SpawnWall(bool isLeft) {
        Vector3 spawnPos = new Vector3(isLeft ? -2.62f : 2.62f, transform.position.y, transform.position.z);

        GameObject newWall = Instantiate(wallPrefab);

        newWall.transform.position = spawnPos;
    }
}
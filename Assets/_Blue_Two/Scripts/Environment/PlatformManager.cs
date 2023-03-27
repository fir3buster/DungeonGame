using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;
    public float respawnTime = 2f;

    [SerializeField]
    GameObject platformPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}

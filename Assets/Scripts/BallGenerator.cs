using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public Vector2 spawnPoint = new Vector2(0f, -4f);
    public bool isDestroyed = true;
    [SerializeField] private GameObject ballPrefab;

    public Vector3 newPos = new Vector3(0f, -4f, 0f);

    private void Update()
    {
        if (isDestroyed)
        {
            Instantiate(ballPrefab, spawnPoint, Quaternion.identity);
            isDestroyed = false;
        }
    }

    public void UnlockMore()
    {
        Destroy(FindObjectOfType<Ball>().gameObject);
        spawnPoint = new Vector2(spawnPoint.x, spawnPoint.y - 4);
        if (spawnPoint.y < -24.25f)
            spawnPoint.y = -24.25f;
    }
}

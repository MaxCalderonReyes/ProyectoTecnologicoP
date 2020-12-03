using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapons;
    [SerializeField]
    float spawnInterval;
    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
      //  Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    void SpawnWeapon(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0,4);
        GameObject weapon = Instantiate(weapons[randomIndex]);

        //Create Position Prefabs 
        float startX = UnityEngine.Random.Range(startPos.x - 20f, startPos.x + 20f); 
        weapon.transform.position = new Vector3(startX, startPos.y, startPos.z);

        //Scale Prefabs
        float scale = UnityEngine.Random.Range(0.8f, 1f);
        weapon.transform.localScale = new Vector2(scale, scale);

        //Speed Prefabs
        float speed = UnityEngine.Random.Range(1f, 2f);
        weapon.GetComponent<WeaponsScript>().StartFloating(speed, endPoint.transform.position.y);
    }

    void AttemptSpawn()
    {
        SpawnWeapon(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 7);
            SpawnWeapon(spawnPos);
        }
    }
}

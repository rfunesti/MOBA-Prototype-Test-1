using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] public Vector3 spawnPoint;
    [SerializeField] public NavPath path;
    [SerializeField] public UnitWave unitWave;
}

public class UnitSpawner : MonoBehaviour
{
    public List<Wave> waves;

    void Start()
    {
        foreach (Wave wave in waves) StartCoroutine(SpawnWave(wave));
    }

    IEnumerator SpawnWave(Wave wave)
    {
        yield return new WaitForSeconds(wave.unitWave.spawnDelay);

        while (true)
        {
            foreach (GameObject prefab in wave.unitWave.prefabs)
            {
                GameObject unit = Instantiate(prefab, wave.spawnPoint, Quaternion.identity, transform);
                unit.GetComponent<FollowPath>().path = wave.path;
                yield return new WaitForSeconds(wave.unitWave.spawnDelay);
            }
            yield return new WaitForSeconds(wave.unitWave.spawnInterval);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RandomType { Random, RoundRobin, RandomNeverTwiceTheSame }

public class SpawnObjectAction : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform[] spawnPositionTransforms;
    [SerializeField] private RandomType randomType;
    private int index = 0;

    public void SpawnMultipleObjects(int number)
    {
        for (int i = 0; i < number; i++)
        {
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        switch (randomType)
        {
            case RandomType.Random: 
                SpawnObjectAtTransform(Utility.Choose(spawnPositionTransforms));
                break;
            case RandomType.RoundRobin:
                index = (index + 1) % spawnPositionTransforms.Length;
                SpawnObjectAtTransform(spawnPositionTransforms[index]);
                break;
            case RandomType.RandomNeverTwiceTheSame:
                index = (index + spawnPositionTransforms.Length - 1) % spawnPositionTransforms.Length;
                SpawnObjectAtTransform(spawnPositionTransforms[index]);
                break;
        }
    }

    private void SpawnObjectAtTransform(Transform spawnTransform)
    {
        Instantiate(prefabToSpawn, spawnTransform.position, spawnTransform.rotation);
    }
    
} 


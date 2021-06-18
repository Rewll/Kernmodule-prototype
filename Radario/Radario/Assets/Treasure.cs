using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{

    [SerializeField] Transform SpawnPlace1;
    [SerializeField] Transform SpawnPlace2;
    [SerializeField] Transform SpawnPlace3;

    // Start is called before the first frame update
    void Awake()
    {
        randomPos();
    }

    void randomPos()
    {
        Vector3 newRandomPos = new Vector3(Random.Range(SpawnPlace1.position.x, SpawnPlace2.position.x), transform.position.y, Random.Range(SpawnPlace1.position.z, SpawnPlace3.position.z));
        transform.position = newRandomPos;
    }
}

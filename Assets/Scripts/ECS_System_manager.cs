using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Collections;
using Unity.Jobs;

public class ECS_System_manager : MonoBehaviour {

    public Text CubesCounter;
    public int NumberOfCubesToSpawn;
    public GameObject Cube;

    private int CubesSpawned;

    // Use this for initialization
    void Start () {
        SpawnCubes();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCubes();
        }
    }

    void SpawnCubes()
    {
        var entityMangager = World.Active.GetOrCreateManager<EntityManager>();

        NativeArray<Entity> CubeArray = new NativeArray<Entity>(NumberOfCubesToSpawn, Allocator.Temp);
        entityMangager.Instantiate(Cube, CubeArray);

        for (int i = 0; i < NumberOfCubesToSpawn; i++)
        {
            entityMangager.AddComponentData(CubeArray[i], new ICD_MoveSpeed { MoveSpeed = 10f });
            entityMangager.AddComponentData(CubeArray[i], new ICD_RotationSpeed { RotationSpeed = 10f });

            float3 StartingPosition = new float3(Random.Range(-100f, 100f), Random.Range(50f, 200f), Random.Range(-100f, 100f));

            entityMangager.SetComponentData(CubeArray[i], new Position { Value = StartingPosition });
        }

        CubeArray.Dispose();

        CubesSpawned += NumberOfCubesToSpawn;
        CubesCounter.text = CubesSpawned.ToString();

    }
}

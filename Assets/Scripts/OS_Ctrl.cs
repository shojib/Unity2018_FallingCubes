using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OS_Ctrl : MonoBehaviour {

    public GameObject Cube;
    public int NumberOfCubesToSpawn;
    public Text CubesCounter;

    private int CubesSpawned;
    private float RandomX;
    private float RandomY;
    private float RandomZ;

    // Use this for initialization
    void Start () {
        SpawnCubes();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCubes();
        }
	}

    void SpawnCubes()
    {
        for (int i = 0; i < NumberOfCubesToSpawn; i++)
        {
            RandomX = Random.Range(-100f, 100f);
            RandomY = Random.Range(50f, 200f);
            RandomZ = Random.Range(-100f, 100f);

            Instantiate(Cube, new Vector3(RandomX, RandomY, RandomZ), Quaternion.identity);
        }

        CubesSpawned += NumberOfCubesToSpawn;
        CubesCounter.text = CubesSpawned.ToString();

    }
}

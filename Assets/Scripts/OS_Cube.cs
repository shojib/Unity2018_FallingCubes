using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OS_Cube : MonoBehaviour {

    private float MoveSpeed = 10f;
    private float RotateSpeed = 50f;

    // Update is called once per frame
    void Update () {
        Vector3 pos = transform.position;
        pos.y -= MoveSpeed * Time.deltaTime;
        transform.position = pos;

        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
	}
}

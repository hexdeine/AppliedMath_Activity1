using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeMovement : MonoBehaviour
{
    float moveX;
    float moveZ;
    public float speed;

    private Vector3 startingPoint = new Vector3(0.0f, 0.79f, -56.82f);

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer() {
        moveX = transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        moveZ = transform.position.z + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector3(moveX, transform.position.y, moveZ);
    }

    public void Respawn() {
        transform.position = startingPoint;
    }
}

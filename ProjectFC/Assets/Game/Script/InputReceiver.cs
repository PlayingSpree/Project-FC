using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReceiver
{
    // Input
    public Vector3 rotation = Vector3.zero;
    public Vector3 movement = Vector3.zero;

    // Calculation Var
    private Vector3 lastMousePos = Input.mousePosition;
    private float deltaTime = 0;
    private Vector3 lastRotation = Vector3.zero;
    private Vector3 lastMovement = Vector3.zero;

    public void Update()
    {
        UpdateMouseKeyboard();
        deltaTime += Time.deltaTime;
    }

    public void Read()
    {
        // Normalize Input
        if (deltaTime == 0)
        {
            rotation = lastRotation;
            movement = lastMovement;
        }
        else
        {
            rotation.Set(rotation.x, rotation.y, rotation.z / deltaTime);
            movement /= deltaTime;
        }
        Debug.Log(movement);
    }

    public void Processed()
    {
        lastRotation = rotation;
        lastMovement = movement;
        rotation.Set(0, 0, 0);
        movement.Set(0, 0, 0);
        deltaTime = 0;
    }

    private void UpdateMouseKeyboard()
    {
        // M+KB
        // Rotation
        float roll = Input.GetKey(GameData.gameSettings.rollLeft) ? Time.deltaTime : 0f;
        roll -= Input.GetKey(GameData.gameSettings.rollRight) ? Time.deltaTime : 0f;
        rotation += new Vector3(Input.mousePosition.y - lastMousePos.y, Input.mousePosition.x - lastMousePos.x, roll);
        lastMousePos = Input.mousePosition;
        // Movement
        float x = Input.GetKey(GameData.gameSettings.right) ? Time.deltaTime : 0f;
        x -= Input.GetKey(GameData.gameSettings.left) ? Time.deltaTime : 0f;
        float y = Input.GetKey(GameData.gameSettings.up) ? Time.deltaTime : 0f;
        y -= Input.GetKey(GameData.gameSettings.down) ? Time.deltaTime : 0f;
        float z = Input.GetKey(GameData.gameSettings.forward) ? Time.deltaTime : 0f;
        z -= Input.GetKey(GameData.gameSettings.backward) ? Time.deltaTime : 0f;
        movement += new Vector3(x, y, z);
    }
}

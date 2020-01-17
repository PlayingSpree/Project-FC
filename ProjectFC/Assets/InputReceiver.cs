using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReceiver
{
    public Vector3 rotation;
    public Vector3 movement;
    Vector3 lastMousePos = Input.mousePosition;

    public void Update()
    {
        // M+KB
        // Rotation
        float roll = Input.GetKey(GameData.gameSettings.rollLeft) ? Time.deltaTime : 0f;
        roll -= Input.GetKey(GameData.gameSettings.rollRight) ? Time.deltaTime : 0f;
        rotation += new Vector3(Input.mousePosition.y - lastMousePos.y, Input.mousePosition.x - lastMousePos.x, roll * 300);
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

    public void Processed()
    {
        rotation.Set(0, 0, 0);
        movement.Set(0, 0, 0);
    }
}

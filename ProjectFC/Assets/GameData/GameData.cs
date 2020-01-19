using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static GameSettings gameSettings;
    public static void LoadSetting()
    {
        gameSettings = new GameSettings();
    }
    public class GameSettings
    {
        public KeyCode forward = KeyCode.W;
        public KeyCode backward = KeyCode.S;
        public KeyCode rollLeft = KeyCode.Q;
        public KeyCode rollRight = KeyCode.E;
        public KeyCode up = KeyCode.LeftShift;
        public KeyCode down = KeyCode.LeftControl;
        public KeyCode left = KeyCode.A;
        public KeyCode right = KeyCode.D;
    }
    public class Suit
    {

    }
    public class GravShoe
    {
        public float rotationSpeed = 600f;
        public float rotationSpeedUp = 0.5f;
        public float rotationSpeedDown = 0.5f;
        public float rotationSpeedLeft = 1.5f;
        public float rotationSpeedRight = 1f;
        public float rollSpeed = 500f;
        public float rollSpeedLeft = 1f;
        public float rollSpeedRight = 1f;
    }
}

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
		public float dragMin = 1f;
		public float dragMax = 3f;
		public float dragAngleMin = 1f;
		public float dragAngleMax = 3f;
		public float weight = 50f;
	}
	public class GravShoe
	{
		public float power = 1200f;
		public float control = 3f;
	}
}

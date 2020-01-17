using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Ref
    private InputReceiver inputReceiver;
    // Status

    // Enquipment
    public GameData.GravShoe shoe = new GameData.GravShoe();
    public GameData.Suit suit = new GameData.Suit();

    private void Awake()
    {
        // Set Ref
        inputReceiver = new InputReceiver();
        GameData.LoadSetting();
    }

    private void Update()
    {
        inputReceiver.Update();
    }

    private void FixedUpdate()
    {
        transform.Rotate(inputReceiver.rotation, Space.Self);
        Vector3 dir = inputReceiver.movement.normalized * 60f * Time.fixedDeltaTime;
        transform.Translate(dir);
        inputReceiver.Processed();
    }
}
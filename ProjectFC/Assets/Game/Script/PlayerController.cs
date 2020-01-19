using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Ref
    private InputReceiver inputReceiver;
    // Status
    private Vector3 targetRotation = Vector3.zero;
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

        // Debug
        Debug.DrawLine(transform.position, transform.position + (transform.rotation * Quaternion.Euler(targetRotation) * Vector3.forward * 3), Color.red);
    }

    private void FixedUpdate()
    {
        inputReceiver.Read();
        // Input
        targetRotation.Set(targetRotation.x, targetRotation.y, 0);
        targetRotation += inputReceiver.rotation;
        targetRotation.Set(Mathf.Clamp(targetRotation.x, -180f, 180f), Mathf.Clamp(targetRotation.y, -180f, 180f), targetRotation.z); // Clamp 180 degree

        // Rotation
        Vector2 normalizeTargetRotation = new Vector2(targetRotation.x, targetRotation.y).normalized * shoe.rotationSpeed;
        normalizeTargetRotation.Set(normalizeTargetRotation.x * (normalizeTargetRotation.x > 0 ? shoe.rotationSpeedUp : shoe.rotationSpeedDown)
            , normalizeTargetRotation.y * (normalizeTargetRotation.y > 0 ? shoe.rotationSpeedRight : shoe.rotationSpeedLeft));
        Vector3 rotationVector = new Vector3(normalizeTargetRotation.x, normalizeTargetRotation.y, shoe.rollSpeed * targetRotation.z * (targetRotation.z > 0 ? shoe.rollSpeedRight : shoe.rollSpeedLeft));
        rotationVector *= Time.fixedDeltaTime;
        rotationVector = NoOvershoot(rotationVector, targetRotation);
        transform.Rotate(rotationVector, Space.Self);
        targetRotation -= rotationVector;



        // Movement
        Vector3 movementDir = inputReceiver.movement.normalized * 60f * Time.fixedDeltaTime;
        transform.Translate(movementDir);
        inputReceiver.Processed();
    }

    private Vector3 NoOvershoot(Vector3 current, Vector3 target)
    {
        return new Vector3(Mathf.Clamp(current.x, -Mathf.Abs(target.x), Mathf.Abs(target.x)), Mathf.Clamp(current.y, -Mathf.Abs(target.y), Mathf.Abs(target.y)), current.z);
    }
}
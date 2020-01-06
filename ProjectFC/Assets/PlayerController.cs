using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Ref
    new Rigidbody rigidbody;
    // Status
    public Vector3 currentForce;
    public Vector3 targetForce;
    public float currentDrag;
    public float targetDrag;
    // Enquipment
    public GameData.GravShoe shoe = new GameData.GravShoe();
    public GameData.Suit suit = new GameData.Suit();

    void Awake()
    {
        // Set Ref
        rigidbody = GetComponent<Rigidbody>();

        // Init stat
        rigidbody.mass = suit.weight;
        currentDrag = suit.dragMax;
        targetDrag = suit.dragMax;

        // Floating Still
        currentForce = rigidbody.mass * -Physics.gravity;
        targetForce = rigidbody.mass * -Physics.gravity;
    }

    void FixedUpdate()
    {
        // Drag
        currentDrag = Mathf.Lerp(currentDrag, targetDrag, Time.fixedDeltaTime * Mathf.Max((200f - suit.weight) / 100f, 1f));
        // Floating


        // Calulate Force
        currentForce = Vector3.Lerp(currentForce, Quaternion.Inverse(transform.rotation) * targetForce, Time.fixedDeltaTime * shoe.control);
        // Add Force
        rigidbody.AddRelativeForce(currentForce, ForceMode.Force);

        Vector3 worldForce = transform.rotation * currentForce;
        Debug.DrawLine(transform.position, transform.position + worldForce);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Rigidbody playerBody;
    private Vector3 _MoveDirection;



    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        _MoveDirection = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerBody.AddForce(_MoveDirection * moveSpeed);

        //handle rotation
        Vector3 currVelocity = playerBody.velocity;
        if (currVelocity.magnitude > .1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currVelocity), Time.deltaTime * rotationSpeed);
        }

    }

    public void OnMove(InputValue value)
    {
        Vector2 newDirection = value.Get<Vector2>();
        _MoveDirection = new Vector3(newDirection.x, 0, newDirection.y);
    }

    public void OnInteract()
    {
        Debug.Log("Interacting!");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;

    [SerializeField] float yForce;
    [SerializeField] float turnSpeed;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * yForce * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            CharacterRotation(turnSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CharacterRotation(-turnSpeed);
        }
    }
    void CharacterRotation(float turnSpeed)
    {
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
    }
}

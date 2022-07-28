using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float yForce;
    [SerializeField] float turnSpeed;
    [SerializeField] AudioClip thrustingAudio;
    Rigidbody m_RigidBody;
    AudioSource m_AudioSource;


    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_RigidBody = GetComponent<Rigidbody>();
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
            m_RigidBody.AddRelativeForce(Vector3.up * yForce * Time.deltaTime);
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.PlayOneShot(thrustingAudio);
            }
        }
        else { m_AudioSource.Stop(); }
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
        m_RigidBody.freezeRotation = true;
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        m_RigidBody.freezeRotation = false;
    }
}

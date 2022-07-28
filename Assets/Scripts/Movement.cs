using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float yForce;
    [SerializeField] float turnSpeed;
    [SerializeField] AudioClip thrustingAudio;
    [SerializeField] ParticleSystem mainThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;

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
                if (!m_AudioSource.isPlaying)
                {
                    m_AudioSource.PlayOneShot(thrustingAudio);
                }
            if (!mainThrustParticles.isPlaying)
            {
                mainThrustParticles.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
            mainThrustParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            CharacterRotation(turnSpeed);
            if (!rightThrustParticles.isPlaying)
            {
                rightThrustParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CharacterRotation(-turnSpeed);
            if (!leftThrustParticles.isPlaying)
            {
                leftThrustParticles.Play();
            }
        }
        else
        {
            rightThrustParticles.Stop();
            leftThrustParticles.Stop();

        }
    }

    void CharacterRotation(float turnSpeed)
    {
        m_RigidBody.freezeRotation = true;
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        m_RigidBody.freezeRotation = false;
    }
}



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

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
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

    private void StopThrusting()
    {
        m_AudioSource.Stop();
        mainThrustParticles.Stop();
    }

    private void RotateLeft()
    {
        CharacterRotation(turnSpeed);
        if (!rightThrustParticles.isPlaying)
        {
            rightThrustParticles.Play();
        }
    }

    private void RotateRight()
    {
        CharacterRotation(-turnSpeed);
        if (!leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Play();
        }
    }

    private void StopRotating()
    {
        rightThrustParticles.Stop();
        leftThrustParticles.Stop();
    }

    void CharacterRotation(float turnSpeed)
    {
        m_RigidBody.freezeRotation = true;
        transform.Rotate(Vector3.back * turnSpeed * Time.deltaTime);
        m_RigidBody.freezeRotation = false;
    }
}



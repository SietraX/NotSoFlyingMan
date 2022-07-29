using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    bool isTransitioning = false;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartCoroutine(NextLevel(1));
                break;
            default:
                StartCoroutine(ReloadLevel(0.5f));
                break;
        }
    }

    IEnumerator ReloadLevel(float delay)
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        m_AudioSource.Stop();
        m_AudioSource.PlayOneShot(crashAudio);
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator NextLevel(float delay)
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Movement>().enabled = false;
        successParticles.Play();
        m_AudioSource.Stop();
        m_AudioSource.PlayOneShot(successAudio);
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Congratulations you beat the game");
        }
    }
}

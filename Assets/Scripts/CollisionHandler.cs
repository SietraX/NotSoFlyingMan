using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
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
        m_AudioSource.Stop();
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    IEnumerator NextLevel(float delay)
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<Movement>().enabled = false;
        m_AudioSource.Stop();
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

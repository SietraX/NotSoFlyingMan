using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    BoxCollider m_BoxCollider;
    bool toggleCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        NoCollision();
        NextLevel();
        PreviousLevel();
    }
    private void NoCollision()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!toggleCollision)
            {
                toggleCollision = true;
                m_BoxCollider.isTrigger = true;
            }
            else
            {
                toggleCollision = false;
                m_BoxCollider.isTrigger = false;
            }
        }
    }

    private void NextLevel()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
            else
            {
                Debug.Log("This level is the last level.");
            }
        }
    }

    private void PreviousLevel()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (0 < currentSceneIndex)
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
            else
            {
                Debug.Log("This level is the first level.");
            }
        }
    }
}

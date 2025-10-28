using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitIntroThingy : MonoBehaviour
{
    public float time_intro = 19f;
    void Start()
    {

        StartCoroutine(waitintro());
    }

    IEnumerator waitintro()
    {
        yield return new WaitForSeconds(time_intro);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("hangiLevel"))
        {
            PlayerPrefs.SetInt("hangiLevel", 1);
        }

        StartCoroutine(SahneyeGit());
    }

    IEnumerator SahneyeGit()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("hangiLevel"));
    }
}

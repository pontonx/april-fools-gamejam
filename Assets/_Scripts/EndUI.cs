using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndUI : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        StartCoroutine(startLaugh());
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.Stop("laugh");
    }

    IEnumerator startLaugh()
    {
        yield return new WaitForSeconds(3f);
        AudioManager.instance.Play("laugh");
    }
}

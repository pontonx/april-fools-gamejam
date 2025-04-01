using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Microwave : MonoBehaviour, InteractableInterface
{
    public string interactableText = "Destroy the clock";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    public void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        if (GameManager.instance.finalQuestDone == 5)
        {
            interactableEnabled = true;
        }
    }
}

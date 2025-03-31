using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffe : MonoBehaviour, InteractableInterface
{
    public string interactableText = "Drink";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    [SerializeField] private GameObject clockPrefab;

    public void Interact()
    {
        Destroy(gameObject);
        if(TaskManager.instance.taskIndex == 3)
        {
            TaskManager.instance.RemoveTask();
            TaskManager.instance.AddTask("Go to the bathroom");
            Instantiate(clockPrefab);
        }
    }
}

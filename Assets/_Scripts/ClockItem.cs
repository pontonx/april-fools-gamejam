using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockItem : MonoBehaviour, InteractableInterface
{
    [SerializeField] private GameObject clockObject;

    public string interactableText = "Pick up";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    public void Interact()
    {
        clockObject.SetActive(true);
        TaskManager.instance.RemoveTask();
        TaskManager.instance.AddTask("What is going on?");
        TimeManager.instance.StopTime();
        Destroy(this.gameObject);
    }
}

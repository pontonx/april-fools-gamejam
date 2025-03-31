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
        Instantiate(clockObject, Camera.main.transform);
        TaskManager.instance.RemoveTask();
        TaskManager.instance.AddTask("What is going on?");
        TimeManager.instance.StopTime();
        DialogueSystem.instance.CustomDialogue("You idiot! I'm a magic clock, the time has stopped!");
        Destroy(this.gameObject);
    }
}

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

    public void Interact()
    {
        clockObject.SetActive(true);
        TimeManager.instance.StopTime();
        Destroy(this.gameObject);
    }
}

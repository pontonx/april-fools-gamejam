using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffComputer : MonoBehaviour, InteractableInterface
{
    [SerializeField] private Material blackMaterial;
    [SerializeField] private MeshRenderer monitorRenderer;

    public string interactableText = "Turn off";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    public void Interact()
    {
        Material[] mats = monitorRenderer.materials;
        mats[1] = blackMaterial;
        monitorRenderer.materials = mats;
        GameManager.instance.FinishQuest();
        Destroy(this);
    }
}

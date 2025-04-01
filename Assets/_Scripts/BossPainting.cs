using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPainting : MonoBehaviour, InteractableInterface
{
    public string interactableText = "Draw";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    [SerializeField] private Material drawedMaterial;
    private MeshRenderer bossMesh;

    private void Start()
    {
        bossMesh = GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        Material[] mats = bossMesh.materials;
        mats[1] = drawedMaterial;
        bossMesh.materials = mats;
        GameManager.instance.FinishQuest();
        AudioManager.instance.Play("spray");
        Destroy(this);
    }
}

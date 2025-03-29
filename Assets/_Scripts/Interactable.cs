using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    void OnPickup(Transform holdPoint);
    void OnDrop();
}

public class Interactable : MonoBehaviour, InteractableInterface, IPickupable
{
    public int itemId = 0;

    public void Interact()
    {
        Debug.Log("Interact");
    }

    private Rigidbody rb;
    private Collider col;

    public string interactableText = "Grab";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public void OnPickup(Transform holdPoint)
    {
        rb.isKinematic = true;
        col.isTrigger = true;
        transform.SetParent(holdPoint);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrop()
    {
        col.isTrigger = false;
        transform.SetParent(null);
        rb.isKinematic = false;
    }
}

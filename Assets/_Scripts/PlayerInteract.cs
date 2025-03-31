using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private KeyCode interactKey = KeyCode.E;

    [SerializeField]
    [Range(0f, 10f)]
    private float range = 5f;

    public TMP_Text itemNameText;
    public Material outlineMaterial;

    [HideInInspector] public List<Material> outlineMaterials;

    public Transform holdPoint;
    private GameObject heldObject;

    void Update()
    {
        if(heldObject == null)
        {
            if(Input.GetMouseButtonDown(0)) TryPickup();
        } 
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                TryDrop();
                rb.velocity = Camera.main.transform.forward * 1000f * Time.deltaTime;
            }
            if (Input.GetMouseButtonDown(1)) TryDrop();
        }

        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, range))
        {
            if (DialogueSystem.instance.isDialogueActive)
            {
                itemNameText.enabled = false;
                return;
            }

            if (hitInfo.collider.TryGetComponent<InteractableInterface>(out InteractableInterface interactable) && heldObject == null)
            {
                if (!interactable.InteractableEnabled) return;

                // Interact with interactable object
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }

                itemNameText.text = interactable.InteractableText;
                itemNameText.enabled = true;
            }
            else
            {
                itemNameText.enabled = false;
            }
        }
        else
        {
            itemNameText.enabled = false;
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            if(hit.collider.TryGetComponent<InteractableInterface>(out InteractableInterface interactable))
            {
                if (!interactable.InteractableEnabled) return;
            }

            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                pickupable.OnPickup(holdPoint);
                heldObject = hit.collider.gameObject;
            } 
        }
    }

    void TryDrop()
    {
        if(heldObject != null)
        {
            IPickupable pickupable = heldObject.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                pickupable.OnDrop();
                heldObject = null;
            }
        }
    }
}

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
    private MeshRenderer previousMesh;
    private List<Material> prevMat = new List<Material>();

    public Transform holdPoint;
    private GameObject heldObject;

    private bool outlineEnabled = false;

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

                // Interact with interactable object
                if (Input.GetKeyDown(interactKey))
                {
                    interactable.Interact();
                }

                // Add outline material
                if (hitInfo.collider.TryGetComponent<MeshRenderer>(out MeshRenderer mesh))
                {
                    if(!outlineEnabled)
                    {
                        outlineEnabled = true;
                        foreach(Material mat in mesh.materials)
                        {
                            outlineMaterials.Add(mat);
                            prevMat.Add(mat);
                        }
                        outlineMaterials.Add(outlineMaterial);
                        mesh.SetMaterials(outlineMaterials);
                    }
                    previousMesh = mesh;
                }

                itemNameText.text = interactable.InteractableText;
                itemNameText.enabled = true;
            }
            else
            {
                itemNameText.enabled = false;
                ResetOutline();
            }
        }
        else
        {
            itemNameText.enabled = false;
            ResetOutline();
        }

        void ResetOutline()
        {
            outlineEnabled = false;

            if (previousMesh != null)
            {
                if(prevMat.Contains(outlineMaterial))
                {
                    prevMat.Remove(outlineMaterial);
                }
                
                if(prevMat.Count > 0)
                {
                    previousMesh.SetMaterials(prevMat);
                }
            }

            outlineMaterials.Clear();
            prevMat.Clear();
        }
    }

    void TryPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
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

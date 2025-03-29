using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour, InteractableInterface
{
    [SerializeField] private Animator handsAnim;

    private Quaternion defaultPos;

    public string interactableText = "Talk";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public bool interactableEnabled = true;
    public bool InteractableEnabled { get => interactableEnabled; set => interactableEnabled = value; }

    public void Interact()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Awake()
    {
        defaultPos = transform.rotation;
    }

    private void Update()
    {
        Vector3 direction = Camera.main.transform.position - transform.position;
        direction.y = 0;

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        if(distance < 3f)
        {
            handsAnim.enabled = false;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        } 
        else
        {
            handsAnim.enabled = true;
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultPos, Time.deltaTime * 5f);
        }
    }
}

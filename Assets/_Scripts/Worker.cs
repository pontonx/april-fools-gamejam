using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour, InteractableInterface
{
    [SerializeField] private Transform head;

    private Quaternion defaultPos;

    public string interactableText = "Talk";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }


    public void Interact()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    private void Awake()
    {
        defaultPos = head.rotation;
    }

    private void Update()
    {
        Vector3 direction = Camera.main.transform.position - head.position;
        direction.y = 0;

        float distance = Vector3.Distance(head.position, Camera.main.transform.position);

        if( distance < 3f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            head.rotation = Quaternion.Slerp(head.rotation, targetRotation, Time.deltaTime * 5f);
            head.rotation = Quaternion.Euler(-90f, head.rotation.eulerAngles.y, head.rotation.eulerAngles.z);
        } 
        else
        {
            head.rotation = Quaternion.Slerp(head.rotation, defaultPos, Time.deltaTime * 5f);
        }
    }
}

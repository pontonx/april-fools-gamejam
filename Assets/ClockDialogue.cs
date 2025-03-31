using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockDialogue : MonoBehaviour
{
    [SerializeField] private GameObject questsPrefab;

    private void Start()
    {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(questsPrefab);
        DialogueSystem.instance.CustomDialogue("Okay... I'll bring back time, just do those pranks that I drew on whiteboard.");
    }
}

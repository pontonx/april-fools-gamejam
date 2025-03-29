using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public bool timeStopped = false;

    [SerializeField] private List<string> scriptNamesToDisable;
    [SerializeField] private List<GameObject> scriptsToEnable;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void StopTime()
    {
        timeStopped = true;

        foreach (string scriptName in scriptNamesToDisable)
        {
            Type scriptType = Type.GetType(scriptName);
            if (scriptType == null) continue;

            MonoBehaviour[] scripts = FindObjectsOfType(scriptType) as MonoBehaviour[];

            foreach (MonoBehaviour foundScript in scripts)
            {
                Destroy(foundScript);
            }
        }

        foreach(GameObject script in scriptsToEnable)
        {
            if(script.TryGetComponent<InteractableInterface>(out InteractableInterface interactable)) {
                interactable.InteractableEnabled = true;
            }
        }

        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators) animator.enabled = false;
    }
}

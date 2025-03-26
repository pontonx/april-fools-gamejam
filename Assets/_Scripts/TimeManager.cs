using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public bool timeStopped = false;

    [SerializeField] private List<string> scriptNamesToDisable;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ResumeTime()
    {
        timeStopped = false;

        foreach (string scriptName in scriptNamesToDisable)
        {
            Type scriptType = Type.GetType(scriptName);
            if (scriptType == null) continue;

            MonoBehaviour[] scripts = FindObjectsOfType(scriptType) as MonoBehaviour[];

            foreach (MonoBehaviour foundScript in scripts)
            {
                foundScript.enabled = true;
            }
        }

        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators) animator.enabled = true;
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
                foundScript.enabled = false;
            }
        }

        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators) animator.enabled = false;
    }
}

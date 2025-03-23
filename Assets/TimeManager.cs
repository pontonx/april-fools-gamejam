using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

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

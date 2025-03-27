using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Script
{
    public Transform scriptHolder;
    public String scriptName;
}

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public bool timeStopped = false;

    [SerializeField] private List<string> scriptNamesToDisable;
    [SerializeField] private List<Script> scriptsToAdd;

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

        foreach(Script script in scriptsToAdd)
        {
            script.scriptHolder.gameObject.AddComponent(Type.GetType(script.scriptName));
        }

        Animator[] animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators) animator.enabled = false;
    }
}

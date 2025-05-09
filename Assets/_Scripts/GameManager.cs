using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int finalQuestDone = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(finalQuestDone == 5)
        {
            FinishQuest();
            TaskManager.instance.RemoveTask();
            TaskManager.instance.AddTask("Destroy the clock!");
            DialogueSystem.instance.CustomDialogue("Hahaha! You thought I will resume time now? You fool!");
        }
    }

    public void FinishQuest()
    {
        finalQuestDone++;
    }

}

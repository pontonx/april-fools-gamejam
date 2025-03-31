using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int finalQuestDone = 0;
    [SerializeField] private TMP_Text doneText;

    public AudioSource dialogueSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
    }

    public void FinishQuest()
    {
        finalQuestDone++;
        doneText.text = finalQuestDone.ToString();
    }

}

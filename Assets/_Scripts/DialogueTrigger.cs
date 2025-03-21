using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueSystem.instance.StartDialogue(dialogue);
        StartCoroutine(SmoothZoom(40f, .75f));
    }

    private IEnumerator SmoothZoom(float targetFOV, float duration)
    {
        float startFOV = Camera.main.fieldOfView;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (!DialogueSystem.instance.isDialogueActive)
            {
                Camera.main.fieldOfView = 60f;
                StopAllCoroutines();
                yield return null;
            }

            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            t = t * t * (3f - 2f * t);
            Camera.main.fieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        Camera.main.fieldOfView = targetFOV;
    }
}

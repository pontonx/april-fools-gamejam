
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    private TMP_Text doneText;
    private void Start()
    {
        doneText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        doneText.text = GameManager.instance.finalQuestDone.ToString();
    }
}

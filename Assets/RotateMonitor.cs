using System.Collections;
using DG.Tweening;
using UnityEngine;

public class RotateMonitor : MonoBehaviour, InteractableInterface
{
    public string interactableText = "Rotate";
    public string InteractableText
    {
        get => interactableText;
        set => interactableText = value;
    }

    public void Interact()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        transform.DOLocalRotate(new Vector3(-90f, 0f, 0f), 1f);
        yield return new WaitForSeconds(1f);
        Destroy(this);
    }
}

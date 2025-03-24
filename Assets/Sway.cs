using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] private float smooth = 5f;
    [SerializeField] private float swayMultiplier = 1.5f;
    [SerializeField] private float returnSpeed = 2f;

    private Quaternion initialLocalRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        mouseX = Mathf.Lerp(0, mouseX, 0.5f);
        mouseY = Mathf.Lerp(0, mouseY, 0.5f);

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        targetRotation = initialLocalRotation * rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    private void LateUpdate()
    {
        targetRotation = Quaternion.Slerp(targetRotation, initialLocalRotation, returnSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float moveAmount = 0.5f; // Maksymalne przesuniêcie
    public float smoothSpeed = 5f; // Prêdkoœæ wyg³adzania ruchu

    private Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float moveX = (mousePos.x - screenWidth / 2) / (screenWidth / 2) * moveAmount; // Ruch w osi X
        float moveZ = (mousePos.y - screenHeight / 2) / (screenHeight / 2) * moveAmount; // Ruch w osi Z

        Vector3 targetLocalPosition = originalLocalPosition + new Vector3(moveX, 0, moveZ);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPosition, Time.deltaTime * smoothSpeed);
    }
}

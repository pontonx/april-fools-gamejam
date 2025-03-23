using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}

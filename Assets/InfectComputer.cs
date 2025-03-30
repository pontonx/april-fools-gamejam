using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectComputer : MonoBehaviour
{
    [SerializeField] private MeshRenderer monitorRenderer;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Pendrive"))
        {
            monitorRenderer.materials[1].color = Color.green;
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Trashcan"))
        {
            GameManager.instance.FinishQuest();
            Destroy(gameObject);
        }
    }
}

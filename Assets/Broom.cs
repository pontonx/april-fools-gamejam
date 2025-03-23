using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 3f))
            {
                if (hitInfo.collider.gameObject == this.gameObject)
                {
                    TaskManager.instance.RemoveTask();
                    TaskManager.instance.AddTask("Clean manager office");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dirt")
        {
            Destroy(other.gameObject);
        }
    }
}

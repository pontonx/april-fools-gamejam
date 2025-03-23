using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToClean;

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

        if(objectsToClean.Count <= 0)
        {
            TaskManager.instance.RemoveTask();
            TaskManager.instance.AddTask("Make a coffee");
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dirt")
        {
            objectsToClean.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}

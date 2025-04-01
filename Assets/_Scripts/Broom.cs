using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    [SerializeField] private GameObject particles;
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
                    if(TaskManager.instance.taskIndex != 2)
                    {
                        TaskManager.instance.RemoveTask();
                        TaskManager.instance.AddTask("Clean office");
                    }
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
            AudioManager.instance.Play("splash", Random.Range(0.8f, 1.2f));
            Instantiate(particles, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}

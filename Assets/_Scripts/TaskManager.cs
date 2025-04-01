using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Task
{
    public string name;
}

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    public int taskIndex = 1;

    public List<Task> tasks = new List<Task>();

    [SerializeField] private Transform TaskHolder;
    [SerializeField] private GameObject taskPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        UpdateTasks();

        AudioManager.instance.Play("yawn");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            RemoveTask();
        }
    }

    public void UpdateTasks()
    {
        foreach(Transform child in TaskHolder)
        {
            Destroy(child.gameObject);
        }

        foreach(Task task in tasks)
        {
            GameObject newTask = Instantiate(taskPrefab, TaskHolder);
            newTask.GetComponent<TMP_Text>().text = task.name;
        }
    }

    public void AddTask(string name)
    {
        Task newTask = new Task();
        newTask.name = name;
        tasks.Add(newTask);
        taskIndex++;
        UpdateTasks();
    }

    public void RemoveTask()
    {
        if(tasks.Count > 0)
        {
            tasks.RemoveAt(0);
            UpdateTasks();
        }
    }

}

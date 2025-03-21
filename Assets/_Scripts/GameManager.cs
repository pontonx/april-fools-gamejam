using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform destination;
    [SerializeField] private List<GameObject> Clients;
    [SerializeField] private GameObject moneyPrefab;

    private NavMeshAgent agent;
    private Animator anim;

    public AudioSource clickSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if(agent != null)
        {
            if (agent.remainingDistance <= 0.1f)
            {
                anim.SetBool("IsWalking", false);
                agent.transform.LookAt(new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z));
            }
            else anim.SetBool("IsWalking", true);
        }
    }

    public void BringClient()
    {
        GameObject client = Instantiate(Clients[0]);
        client.name = "Client";
        anim = client.GetComponentInChildren<Animator>();
        agent = client.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }

    public void SpawnMoney()
    {
        GameObject money = Instantiate(moneyPrefab);
        money.name = "Money";
    }
}

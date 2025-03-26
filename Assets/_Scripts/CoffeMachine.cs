using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMachine : MonoBehaviour
{
    [SerializeField] private GameObject filledCup;

    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Transform cupHolder;

    private bool isActive = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cup") && !isActive)
        {
            isActive = true;
            GameObject cup = collision.gameObject;
            Destroy(cup.GetComponent<Interactable>());
            Destroy(cup.GetComponent<Rigidbody>());
            cup.transform.SetParent(cupHolder);
            cup.transform.localRotation = Quaternion.identity;
            cup.transform.localPosition = Vector3.zero;
            StartCoroutine(fillCup(cup));
        }
    }

    IEnumerator fillCup(GameObject cup)
    {
        particles.Play();
        yield return new WaitForSeconds(10f);
        particles.Stop();
        GameObject newCup = Instantiate(filledCup, cupHolder);
        Destroy(cup);
        isActive = false;
    }
}

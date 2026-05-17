using System.Collections;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public GameObject firstCustomer;
    public Transform customerSpawnPoint;

    public float firstCustomerDelay = 5f;

    private bool firstCustomerStarted = false;

    public void StartFirstCustomerTimer()
    {
        if (firstCustomerStarted)
            return;

        firstCustomerStarted = true;
        StartCoroutine(FirstCustomerRoutine());
    }

    IEnumerator FirstCustomerRoutine()
    {
        yield return new WaitForSeconds(firstCustomerDelay);

        firstCustomer.transform.position = customerSpawnPoint.position;
        firstCustomer.transform.rotation = customerSpawnPoint.rotation;

        firstCustomer.SetActive(true);
    }
}
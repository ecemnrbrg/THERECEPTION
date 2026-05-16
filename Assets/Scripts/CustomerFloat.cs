using UnityEngine;

public class CustomerFloat : MonoBehaviour
{
    public float floatAmount = 0.03f;
    public float floatSpeed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos +
            Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatAmount;
    }
}
using System.Collections;
using UnityEngine;

public class DoorStoryInteraction : MonoBehaviour
{
    [Header("Camera")]
    public Camera mainCamera;
    public Transform cameraPoint;
    public float cameraMoveSpeed = 3f;

    [Header("3D Door")]
    public Animator doorAnimator;

    [Header("Story UI")]
    public GameObject storyPanel;
    public Animator storyAnimator;

    [Header("Player")]
    public MonoBehaviour playerMovementScript;

    private bool playerNear = false;
    private bool isPlaying = false;

    void Start()
    {
        storyPanel.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E) && !isPlaying)
        {
            StartCoroutine(OpenDoorAndStory());
        }
    }

    IEnumerator OpenDoorAndStory()
    {
        isPlaying = true;

        if (playerMovementScript != null)
            playerMovementScript.enabled = false;

        while (Vector3.Distance(mainCamera.transform.position, cameraPoint.position) > 0.05f)
        {
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position,
                cameraPoint.position,
                Time.deltaTime * cameraMoveSpeed
            );

            mainCamera.transform.rotation = Quaternion.Lerp(
                mainCamera.transform.rotation,
                cameraPoint.rotation,
                Time.deltaTime * cameraMoveSpeed
            );

            yield return null;
        }

        mainCamera.transform.position = cameraPoint.position;
        mainCamera.transform.rotation = cameraPoint.rotation;

        // Kapı ve image aynı anda başlar
        doorAnimator.SetTrigger("Open");

        storyPanel.SetActive(true);
        storyAnimator.SetTrigger("FadeIn");
    }

    public void CloseStory()
    {
        storyPanel.SetActive(false);

        if (playerMovementScript != null)
            playerMovementScript.enabled = true;

        isPlaying = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}
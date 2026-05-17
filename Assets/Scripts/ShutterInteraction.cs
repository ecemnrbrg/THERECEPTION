using UnityEngine;
using TMPro;
using System.Collections;

public class ShutterInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public GameFlowManager gameFlowManager;
    public float interactDistance = 3f;
    public float stopAfterSeconds = 1.2f;

    public TextMeshProUGUI shutterText;

    public Animator shutterAnimator;
    public FPSController fpsController;

    private bool shutterOpened = false;

    void Start()
    {
        shutterText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (shutterOpened)
            return;

        CheckShutterButton();
    }

    void CheckShutterButton()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("ShutterButton"))
            {
                shutterText.gameObject.SetActive(true);

                if (!GameProgress.noteRead)
                {
                    shutterText.text = "Read the note first";
                    return;
                }

                shutterText.text = "[E] Open Shutters";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenShutter();
                }

                return;
            }
        }

        shutterText.gameObject.SetActive(false);
    }

    void OpenShutter()
    {
        shutterOpened = true;

        gameFlowManager.StartFirstCustomerTimer();

        shutterText.gameObject.SetActive(false);

        shutterAnimator.SetTrigger("Open");

        fpsController.canMove = true;

        StartCoroutine(StopShutterAnimation());
    }

    IEnumerator StopShutterAnimation()
    {
        yield return new WaitForSeconds(stopAfterSeconds);

        shutterAnimator.speed = 0f;
    }
}
using UnityEngine;
using TMPro;

public class NoteInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 3f;

    public TextMeshProUGUI interactionText;

    public GameObject notePanel;

    public FPSController fpsController;

    public GameObject noteGlow;

    private bool noteOpen = false;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
        notePanel.SetActive(false);
    }

    void Update()
    {
        if (noteOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CloseNote();
            }

            return;
        }

        CheckNoteLook();
    }

    void CheckNoteLook()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Note"))
            {
                interactionText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    OpenNote();
                }

                return;
            }
        }

        interactionText.gameObject.SetActive(false);
    }

    void OpenNote()
    {
        noteOpen = true;

        notePanel.SetActive(true);

        interactionText.gameObject.SetActive(false);

        fpsController.enabled = false;

        noteGlow.SetActive(false);

        GameProgress.noteRead = true;
    }

    void CloseNote()
    {
        noteOpen = false;

        notePanel.SetActive(false);

        fpsController.enabled = true;
    }
}
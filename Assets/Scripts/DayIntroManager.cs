using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayIntroManager : MonoBehaviour
{
    public Image blackPanel;
    public TextMeshProUGUI dayText;

    public float letterDelay = 0.15f;
    public float waitAfterText = 1f;
    public float fadeTime = 2f;

    public AudioSource typeSound;

    private string fullText = "DAY 1";

    void Start()
    {
        StartCoroutine(DayIntro());
    }

    IEnumerator DayIntro()
    {
        blackPanel.gameObject.SetActive(true);
        dayText.gameObject.SetActive(true);

        Color panelColor = blackPanel.color;
        panelColor.a = 1f;
        blackPanel.color = panelColor;

        dayText.text = "";

        foreach (char letter in fullText)
        {
            dayText.text += letter;

            if (typeSound != null)
            {
                typeSound.Play();
            }

            yield return new WaitForSeconds(letterDelay);
        }

        yield return new WaitForSeconds(waitAfterText);

        dayText.gameObject.SetActive(false);

        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);

            panelColor.a = alpha;
            blackPanel.color = panelColor;

            yield return null;
        }

        blackPanel.gameObject.SetActive(false);
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIO : MonoBehaviour
{
    [SerializeField] private Image image;     // Referencia a la imagen
    [SerializeField] private float duration = 1f; // Tiempo del fade

    private Coroutine currentFade;
    
    public float Duration => duration;

    public void FadeIn()
    {
        StartFade(0f, 1f);
    }

    public void FadeOut()
    {
        StartFade(1f, 0f);
    }

    public void SetActive(bool active, float fillAmount)
    {
        image.gameObject.SetActive(active);
        image.fillAmount = fillAmount;
    }

    private void StartFade(float start, float end)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeRoutine(start, end));
    }

    private IEnumerator FadeRoutine(float start, float end)
    {
        float elapsed = 0f;

        image.fillAmount = start;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            image.fillAmount = Mathf.Lerp(start, end, t);

            yield return null;
        }

        image.fillAmount = end;
    }
}
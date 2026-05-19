using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject realityObjects;
    [SerializeField] private GameObject dreamObjects;
    [SerializeField] private PlayerInputHandler input;


    [SerializeField] private Image transitionImage;
    [SerializeField] private float transitionTime = 0.2f;


    [Header("Dream settings")]
    [SerializeField] private float dreamDuration = 3f;
    [SerializeField] private float coolDown = 5f;
    [SerializeField] private Image dreamBar;

    private bool isDream = false;
    private float dreamTimer = 0f;
    private float coolDownTimer = 0f;

    private void Start()
    {
        isDream = false;

        realityObjects.SetActive(true);
        dreamObjects.SetActive(false);
    }

    private void Update()
    {
        if(coolDownTimer > 0)
            coolDownTimer -= Time.deltaTime;

        if (isDream)
        {
            dreamTimer -= Time.deltaTime;

            if(dreamTimer <= 0)
            {
                StartCoroutine(SwitchEffect(false));
            }
        }

        if (input.SwitchWorldPressed && !isDream && coolDownTimer <= 0)
        {
            StartCoroutine(SwitchEffect(true));
        }

        UpdateBar();
    }

    private void EnterDream()
    {
        isDream = true;
        dreamTimer = dreamDuration;

        realityObjects.SetActive(false);
        dreamObjects.SetActive(true);
    }

    private void ExitDream()
    {
        isDream = false;
        coolDownTimer = coolDown;

        realityObjects.SetActive(true);
        dreamObjects.SetActive(false);
    }

    private void UpdateBar()
    {
        if (isDream)
        {
            dreamBar.fillAmount = dreamTimer / dreamDuration;
        }
        else if (coolDownTimer > 0)
        {
            dreamBar.fillAmount = 1 - (coolDownTimer / coolDown);
        }
        else
        {
            dreamBar.fillAmount = 1;
        }
    }

    private IEnumerator SwitchEffect(bool enterDream)
    {
        yield return Fade(0f, 1f);

        if (enterDream)
            EnterDream();
        else
            ExitDream();

        yield return Fade(1f, 0f);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;

        Color color = transitionImage.color;

        while (time < transitionTime)
        {
            float t = time / transitionTime;

            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            transitionImage.color = color;

            time += Time.deltaTime;
            yield return null;
        }

        color.a = endAlpha;
        transitionImage.color = color;
    }
}
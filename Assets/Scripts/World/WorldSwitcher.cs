using UnityEngine;
using UnityEngine.UI;

public class WorldSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject realityObjects;
    [SerializeField] private GameObject dreamObjects;
    [SerializeField] private PlayerInputHandler input;

    [Header("Dream settings")]
    [SerializeField] private float dreamDuration = 3f;
    [SerializeField] private float coolDown = 10f;
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
                ExitDream();
            }
        }

        if (input.SwitchWorldPressed && !isDream && coolDownTimer <= 0)
        {
            EnterDream();
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
}
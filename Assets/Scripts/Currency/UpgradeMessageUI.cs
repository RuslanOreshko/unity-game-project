using TMPro;
using UnityEngine;
using System.Collections;

public class UpgradeMessageUI : MonoBehaviour
{
    [SerializeField] private GameObject messageObject;
    [SerializeField] private TMP_Text messageText;

    public void ShowMessage(string text)
    {
        StartCoroutine(ShowRoutine(text));
    }

    private IEnumerator ShowRoutine(string text)
    {
        messageText.text = text;

        messageObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        messageObject.SetActive(false);
    }
}
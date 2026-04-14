using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject realityObjects;
    [SerializeField] private GameObject dreamObjects;
    [SerializeField] private PlayerInputHandler input;

    private bool isDream = false;

    private void Update()
    {
        if (input.SwitchWorldPressed)
        {
            SwitchWorld();
        }
    }

    private void SwitchWorld()
    {
        isDream = !isDream;

        realityObjects.SetActive(!isDream);
        dreamObjects.SetActive(isDream);
    }
}
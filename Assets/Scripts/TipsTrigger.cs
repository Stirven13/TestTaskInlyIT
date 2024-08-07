using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [Header("Текст подсказки")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() == null) { return; }
        isPlayerInside = true;
        TipsManager.displayTipEvent?.Invoke(message);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() == null) { return; }
        isPlayerInside = false;
        TipsManager.disableTipEvent?.Invoke();
    }

    private void OnDestroy()
    {
        if (isPlayerInside)
        {
            TipsManager.disableTipEvent?.Invoke();
        }
    }
}

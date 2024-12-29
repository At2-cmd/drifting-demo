using System;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public Action<Transform> OnTriggered { get; set; }
    [SerializeField] private string tagName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            OnTriggered?.Invoke(other.transform);
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
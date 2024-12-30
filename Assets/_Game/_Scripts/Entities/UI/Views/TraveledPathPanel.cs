using System;
using TMPro;
using UnityEngine;

public class TraveledPathPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _traveledPathText;

    public void SetTravelledPathText(int travelledAmount)
    {
        _traveledPathText.text = travelledAmount.ToString();
    }

    public void ResetTravelledPath()
    {
        SetTravelledPathText(0);
    }
}

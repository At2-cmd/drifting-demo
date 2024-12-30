using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedPanelView : MonoBehaviour
{
    [SerializeField] private Image speedometerImage;
    [SerializeField] private TMP_Text speedText;
    private float _shownSpeedMultiplier = 4.5f;

    public void AdjustSpeedMeter(float value, int minSpeed, int maxSpeed)
    {
        float normalizedValue = (float)(value - minSpeed) / (maxSpeed - minSpeed);
        speedometerImage.fillAmount = Mathf.Clamp01(normalizedValue);
        speedText.text = (value * _shownSpeedMultiplier).ToString("F0");
    }
}

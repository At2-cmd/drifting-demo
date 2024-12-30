using TMPro;
using UnityEngine;

public class CoinsPanelView : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    private int _collectedCoins;

    public void ResetCoins()
    {
        _collectedCoins = 0;
        SetCoinsText();
    }

    public void IncreaseCoins()
    {
        _collectedCoins++;
        SetCoinsText();
    }

    private void SetCoinsText()
    {
        coinsText.text = _collectedCoins.ToString();
    }
}

using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int ValueOfCoinsObtainedOnLevel;
    [SerializeField] private TextMeshProUGUI textCounter;
    public void AddCoin(int value)
    {
        ValueOfCoinsObtainedOnLevel += value;
        textCounter.text = ValueOfCoinsObtainedOnLevel.ToString();
    }
}

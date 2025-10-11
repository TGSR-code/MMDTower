using TMPro;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMoneyText;
    [SerializeField] private AudioSource moneyGainSound;
    [SerializeField] private int startMoney = 500;

    private int currentMoney;

    void Start()
    {
        currentMoney = startMoney;
        UpdateMoneyText();
    }

    
    public void GainMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
        if (moneyGainSound != null)
            moneyGainSound.Play();
    }

    public void UpdateMoneyText()
    {

    }
}

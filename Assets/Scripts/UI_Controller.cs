using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _totalClicks;

    [SerializeField]
    private Button[] _enemiesCounterButtons = new Button[3];

    [UsedImplicitly]
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void UpdateScore(int amount)
    {
        var counter = amount.ToString();
        _totalClicks.text = "Total clicks  " + counter;
    }

    public void SetEnemiesAmount(int[] arrayCounter)
    {
        for (int i = 0; i < 3; i++)
        {
            _enemiesCounterButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = arrayCounter[i].ToString();
        }
    }
    public void UpdateEnemiesAmount(Color playerColor)
    {
        for (int i = 0; i < 3; i++)
        {
            var enemysColor = _enemiesCounterButtons[i].GetComponent<Image>().color;
            if (Mathf.Approximately(playerColor.r, enemysColor.r) &&
                Mathf.Approximately(playerColor.g, enemysColor.g) &&
                Mathf.Approximately(playerColor.b, enemysColor.b))
            {
                var amountEnemiesText = _enemiesCounterButtons[i].GetComponentInChildren<TextMeshProUGUI>().text;
                int amountAliveEnemies = Convert.ToInt32(amountEnemiesText);
                _enemiesCounterButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = (amountAliveEnemies - 1).ToString();
            }
        }
    }
}

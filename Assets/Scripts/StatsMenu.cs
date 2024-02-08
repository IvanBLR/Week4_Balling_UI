using System;
using DefaultNamespace;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _clicks;
    [SerializeField] private TextMeshProUGUI _enemies;

    [SerializeField] private GameObject _winPoints;
    [SerializeField] private GameObject _statsButton;

    private void OnEnable()
    {
        _bestScore.text = PlayerPrefs.GetFloat(GameConstant.BEST_SCORE).ToString();
        _time.text = PlayerPrefs.GetFloat(GameConstant.TOTAL_TIME).ToString();
        _clicks.text = PlayerPrefs.GetFloat(GameConstant.TOTAL_CLICKS).ToString();
        _enemies.text = PlayerPrefs.GetFloat(GameConstant.ENEMIES_POINTS).ToString();
    }


    [UsedImplicitly] // назначен на крестик
    public void CloseStatsMenu()
    {
        gameObject.SetActive(false);
        _winPoints.SetActive(true);
        _statsButton.SetActive(true);
    }
}
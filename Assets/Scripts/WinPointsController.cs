using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WinPointsController : MonoBehaviour
{
    // цвет врагов: зеленый 0.9, желтый 1.2, красный 1.9
    // показания таймера: логарифмическая функция y = -10 * ln(x) (время должно измеряться в МИНУТАХ!, причем не более 59 секунд)
    //                     за 10 сек = примерно 17 очков, за 30 сек = примерно 7 очков
    // количество кликов мышки: обратная зависимость y = 100 / x
    // штрафные очки за уничтожение врага (красный кубик дотронулся до красного цилиндра): 80% от стоимости врага
    // бонусные очки за быстрое скольжение: это показатель слайдера Force / 1000 (от 0.3 до 1)

    public Action GameFinished;
    
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private OutsidePlayerAndEnemyController _outsideController;
    [SerializeField] private Slider _forceSlider;
    [SerializeField] private TextMeshProUGUI _timer;
   
    private int _enemyAmount = 6;
    private float _time;// done. уже сразу в виде sec/min
    private float _enemies; // done
    private float _mouseClick; // done
    private float _failPoints; // done
    private float _force; //done
    private bool _isGameStarted;

    private void Start()
    {
        _playerController.OnTouchedEnemyEvent += EnemyPointsUpdate;
        _outsideController.EnemyDie += EnemyPointsCounter;
        _force = _forceSlider.value;
        PlayerPrefs.SetFloat(GameConstant.FORCE, _forceSlider.value);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (_isGameStarted)
        {
            _time += Time.deltaTime;
            _timer.text = Math.Floor(_time).ToString();
        }
        if (_enemyAmount <= 0)
        {
            _isGameStarted = false;
            _playerController.OnMouseClickEvent = null;
            PlayerPrefs.SetFloat(GameConstant.TOTAL_TIME, (float)(Math.Round(_time, 2) / 60));
            PlayerPrefs.Save();
            GameFinished?.Invoke();
        }
    }

    private void OnDestroy()
    {
        _playerController.OnTouchedEnemyEvent -= EnemyPointsUpdate;
        _outsideController.EnemyDie -= EnemyPointsCounter;
    }

    [UsedImplicitly] // назначен на слайдер
    public void ChangeForce()
    {
        _force = _forceSlider.value;
        PlayerPrefs.SetFloat(GameConstant.FORCE, _force);
        PlayerPrefs.Save();
    }

    public void GameStarted() => _isGameStarted = true;
    private void EnemyPointsUpdate(Color color)
    {
        float winPoint = 0;

        if (color.Equals(Color.yellow))
            winPoint = 1.2f * 0.8f;

        if (color.Equals(Color.red))
            winPoint = 1.9f * 0.8f;

        if (color.Equals(Color.green))
            winPoint = 0.9f * 0.8f;

        EnemyPointsCounter(winPoint);
    }

    private void EnemyPointsCounter(float winPoint)
    {
        _enemyAmount--;
        _enemies += winPoint;
        PlayerPrefs.SetFloat(GameConstant.ENEMIES_POINTS, _enemies);
        PlayerPrefs.Save();
    }
}
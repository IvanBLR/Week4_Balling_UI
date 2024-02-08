using System;
using DefaultNamespace;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Action GameStarted;

    [SerializeField] private Material _gameFinishMaterial;

    [SerializeField] private GameObject _plane;
    [SerializeField] private SecondSlide _secondSlide;

    [SerializeField] private TextMeshProUGUI _totalClicks;
    [SerializeField] private TextMeshProUGUI _totalPoints;

    [SerializeField] private Canvas _gameCanvas;
    [SerializeField] private Canvas _instructionCanvas;
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _settingsCanvas;
    [SerializeField] private Canvas _gameOver;

    [SerializeField] private GameObject[] _instructionSlides;

    [SerializeField] private Sprite[] _soundPictures;

    [SerializeField] private Button _previousButton;

    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _soundTumbler;

    private int _currentSlideNumber;
    private bool _isSoundOn;

    private void Start()
    {
        _currentSlideNumber = 0;
        _isSoundOn = true;
    }

    private void OnEnable()
    {
        _secondSlide.AnimationCompleted += ActivateButtons;
    }

    private void OnDisable()
    {
        _secondSlide.AnimationCompleted -= ActivateButtons;
    }

    [UsedImplicitly]
    public void NextInstructionSlide()
    {
        _instructionSlides[_currentSlideNumber].gameObject.SetActive(false);
        _instructionSlides[_currentSlideNumber + 1].gameObject.SetActive(true);

        _currentSlideNumber++;
        _previousButton.interactable = true;

        _secondSlide.ActivateSecondSlid(_currentSlideNumber == 1);

        if (_currentSlideNumber >= _instructionSlides.Length - 1)
        {
            _nextButton.interactable = false;
        }

        if (_currentSlideNumber == 1)
        {
            _previousButton.interactable = false;
            _nextButton.interactable = false;
        }
    }

    [UsedImplicitly]
    public void PreviousInstructionSlide()
    {
        _instructionSlides[_currentSlideNumber].gameObject.SetActive(false);
        _instructionSlides[_currentSlideNumber - 1].gameObject.SetActive(true);

        _currentSlideNumber--;
        _nextButton.interactable = true;

        _secondSlide.ActivateSecondSlid(_currentSlideNumber == 1);

        if (_currentSlideNumber <= 0)
        {
            _previousButton.interactable = false;
        }

        if (_currentSlideNumber == 1)
        {
            _previousButton.interactable = false;
            _nextButton.interactable = false;
        }
    }


    [UsedImplicitly] // назначен на кнопку переключения звука
    public void TurnPicturesSoundOnOff()
    {
        _isSoundOn = !_isSoundOn;
        if (_isSoundOn)
            _soundTumbler.image.sprite = _soundPictures[0];
        else
            _soundTumbler.image.sprite = _soundPictures[1];
    }

    [UsedImplicitly] // вызов меню инструкций
    public void CallInstruction()
    {
        _instructionCanvas.gameObject.SetActive(true);
        _mainCanvas.gameObject.SetActive(false);
    }

    [UsedImplicitly] // вызов меню настроек
    public void CallSettings()
    {
        _settingsCanvas.gameObject.SetActive(true);
        _mainCanvas.gameObject.SetActive(false);
    }

    [UsedImplicitly] // возврат в главное меню
    public void CallMainMenu()
    {
        _mainCanvas.gameObject.SetActive(true);
        _instructionCanvas.gameObject.SetActive(false);
        _settingsCanvas.gameObject.SetActive(false);
    }

    [UsedImplicitly] // назначить на кнопку Старт Гейм
    public void StartGame()
    {
        GameStarted?.Invoke();
        _gameCanvas.gameObject.SetActive(true);
        _gameOver.gameObject.SetActive(false);
        _mainCanvas.gameObject.SetActive(false);
        _settingsCanvas.gameObject.SetActive(false);
        _instructionCanvas.gameObject.SetActive(false);
    }

    [UsedImplicitly]
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ActivateGameOverScreen()
    {
        _gameOver.gameObject.SetActive(true);
        _gameCanvas.gameObject.SetActive(false);
        _mainCanvas.gameObject.SetActive(false);
        _settingsCanvas.gameObject.SetActive(false);
        _instructionCanvas.gameObject.SetActive(false);

        _totalPoints.text = PlayerPrefs.GetFloat(GameConstant.CURRENT_SCORE).ToString();

        _plane.gameObject.GetComponent<MeshRenderer>().material = _gameFinishMaterial;
    }

    public void UpdateScore(int amount)
    {
        _totalClicks.text = amount.ToString();
        PlayerPrefs.SetFloat(GameConstant.TOTAL_CLICKS, amount);
        PlayerPrefs.Save();
    }

    private void ActivateButtons()
    {
        _nextButton.interactable = true;
        _previousButton.interactable = true;
    }
}
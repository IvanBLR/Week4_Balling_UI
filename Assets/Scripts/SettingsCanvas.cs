using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
   [SerializeField] private Canvas _statsCanvas;
   
   [SerializeField] private Slider _slider;
   [SerializeField] private Button _stats;
   [SerializeField] private Button _sound;

   [UsedImplicitly]
   public void CallStatsMenu()
   {
      _statsCanvas.gameObject.SetActive(true);
      _slider.gameObject.SetActive(false);
      _sound.gameObject.SetActive(false);
      _stats.gameObject.SetActive(false);
   }

   [UsedImplicitly]
   public void ActivateUIElements()
   {
      _slider.gameObject.SetActive(true);
      _stats.gameObject.SetActive(true);
      _sound.gameObject.SetActive(true);
   }
}

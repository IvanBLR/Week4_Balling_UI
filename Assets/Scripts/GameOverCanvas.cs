
using JetBrains.Annotations;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
   [SerializeField] private GameObject _winPoints;
   [SerializeField] private GameObject _statsButton;
   [SerializeField] private Canvas _stats;
   
   [UsedImplicitly]
   public void CallStats()
   {
      _winPoints.SetActive(false);
      _statsButton.SetActive(false);
      _stats.gameObject.SetActive(true);
   }
}

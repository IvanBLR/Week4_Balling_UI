using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPointsController : MonoBehaviour
{
   /// цвет врагов: чем тяжелее враги - тем больше за них очков
   /// показания таймера: обратная зависимость (типа 0 сек = 60 очков, 1 сек = 59 очков, 6 сек = 54 очка)
   /// количество кликов мышки: обратная зависимость, как и у таймера
   /// штрафные очки за уничтожение врага (красный кубик дотронулся до красного цилиндра)

   private float _time;
   private float _enemies;
   private float _mouseCick;
   private float _failPoints;
}

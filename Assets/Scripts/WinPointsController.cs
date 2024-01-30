using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPointsController : MonoBehaviour
{
   /// цвет врагов: зеленый 1, желтый 1.2, красный 1.9
   /// показания таймера: логарифмическая функция y = -10 * ln(x) (время должно измеряться в МИНУТАХ!, причем не более 59 секунд)
   ///                     за 10 сек = примерно 17 очков, за 30 сек = примерно 7 очков
   /// количество кликов мышки: обратная зависимость y = 100 / x
   /// штрафные очки за уничтожение врага (красный кубик дотронулся до красного цилиндра): 80% от стоимости врага
   /// бонусные очки за быстрое скольжение: это показатель слайдера Force / 1000 (от 0.5 до 1)

   private float _time;
   private float _enemies;
   private float _mouseClick;
   private float _failPoints;
   private float _force;
}

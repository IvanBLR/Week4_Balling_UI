using Unity.VisualScripting;
using UnityEngine;

public class CylindrSpawner : MonoBehaviour
{
    /// <summary>
    /// с помощью параметра colorNumber мы получаем индекс цвета в массиве Color из класса GameManager
    /// каждый индекс соответствует определённому цвету. Этот индекс важен для расчёта победных очков:
    /// чем тяжелее enemy - тем больше очков за него можно получить.
    /// Реализация калечная, но я не хочу ничего переделывать
    /// </summary>
    public void Initialize(GameObject enemyPrefab, Vector3 position, Color color, int colorNumber = 0)
    {
        switch (colorNumber)
        {
            case 1:
                enemyPrefab.GetComponent<Rigidbody>().mass = 2;
                break;
            case 2:
                enemyPrefab.GetComponent<Rigidbody>().mass = 6;
                break;
            default:
                enemyPrefab.GetComponent<Rigidbody>().mass = 15;
                break;
        }

        GameObject enemy = Instantiate(enemyPrefab, transform, true);
        enemy.transform.position = position;

        enemy.GetComponent<MeshRenderer>().material.color = color;
        enemy.gameObject.layer = colorNumber;
    }
}
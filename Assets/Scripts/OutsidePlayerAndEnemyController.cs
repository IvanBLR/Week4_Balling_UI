using System;
using DefaultNamespace;
using UnityEngine;

public class OutsidePlayerAndEnemyController : MonoBehaviour
{
    public Action<float> EnemyDie;

    private int _playerFalled;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _playerFalled++;
            PlayerPrefs.SetInt(GameConstant.PLAYER_OUTSIDE, _playerFalled);
            PlayerPrefs.Save();

            collision.gameObject.transform.SetPositionAndRotation(new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.transform.GetComponent<Rigidbody>().Sleep();
        }

        if (collision.transform.tag == "Enemy")
        {
            var enemy = collision.gameObject.GetComponent<MeshRenderer>().material.color;

            if (enemy.Equals(Color.red))
                EnemyDie?.Invoke(2.1f);

            if (enemy.Equals(Color.green))
                EnemyDie?.Invoke(0.9f);

            if (enemy.Equals(Color.yellow))
                EnemyDie?.Invoke(1.2f);

            Destroy(collision.gameObject);
        }
    }
}
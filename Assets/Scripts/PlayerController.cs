using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public Action<int> OnMouseClickEvent;
    public Action<Color> OnTouchedEnemyEvent;

    [SerializeField]
    private Slider _force;

    private int _clickCounter;
    private Rigidbody _rigidbody;

    private Stopwatch _stopwatch;
    private Color _playerColor;

    private void Start()
    {
        _stopwatch = new Stopwatch();
        _force.value = 650;
        _rigidbody = GetComponent<Rigidbody>();
        _playerColor = transform.GetComponent<MeshRenderer>().material.color;
        _playerColor.a = 1;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _stopwatch.Restart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            _stopwatch.Stop();

            if (Physics.Raycast(ray, out var hitInfo))
            {
                var directionForce = (hitInfo.point - transform.position).normalized;
                var multiplier = Mathf.Clamp((float)_stopwatch.Elapsed.TotalSeconds, 0.1f, 1);
                PlayersMoving(directionForce, multiplier);
                _clickCounter++;
                OnMouseClickEvent?.Invoke(_clickCounter);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (_playerColor.Equals(collision.transform.GetComponent<MeshRenderer>().material.color))
            {
                OnTouchedEnemyEvent?.Invoke(_playerColor);
                Destroy(collision.gameObject);
            }
        }
    }
    public void UpdatePlayersColor(Color newColor)
    {
        _playerColor = newColor;
    }
    private void PlayersMoving(Vector3 directionForce, float multiplier)
    {
        _rigidbody.AddForce(directionForce * _force.value * multiplier);
    }

}


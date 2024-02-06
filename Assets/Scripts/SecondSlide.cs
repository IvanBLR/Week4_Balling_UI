using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class SecondSlide : MonoBehaviour
{
    public Action AnimationCompleted;
    
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _enemy;

    private bool _isSlideActive;
    //private bool _isAnimationCompleted;
    private Vector3 _startCubePosition;
    private Color _startColor;

    private void Start()
    {
        _startCubePosition = transform.position;
        _startColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void Update()
    {
        if (_isSlideActive)
        {
            StartCoroutine(StartAnimation());
            _isSlideActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = other.GetComponent<MeshRenderer>().material.color;
        }

        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }

  //  private void OnDisable() => AnimationCompleted?.Invoke();

    public void ActivateSecondSlid(bool value) => _isSlideActive = value;

    private IEnumerator StartAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(_sphere.transform.position, 1.4f));
        sequence.Append(transform.DOMove(_enemy.transform.position, 1.4f));
        sequence.OnComplete(() =>
        {
            transform.position = _startCubePosition;
            gameObject.GetComponent<MeshRenderer>().material.color = _startColor;
            _enemy.SetActive(true);
            AnimationCompleted?.Invoke();
        });
        yield break;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class ThirdSlide : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private GameObject _enemy;
    private Material _startMaterial;
    private bool _isAnimationActive;
    private Vector3 _startCubePosition;

    private void Start()
    {
        _startCubePosition = transform.position;
        _startMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if (_isAnimationActive)
        {
            transform.DOMoveX(_sphere.transform.position.x + 2, 1.4f);
            transform.DOMove(_enemy.transform.position, 1.4f)
                .SetDelay(1.6f)
                .OnComplete(RefreshExample);
            _isAnimationActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            var material = other.gameObject.GetComponent<MeshRenderer>().materials[0];
            var renderer = gameObject.GetComponent<MeshRenderer>();
            renderer.material = material;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }

    [UsedImplicitly] // TODO: надо назначить на кнопкИ активации этого слайда
    public void ActivateThirdSlid() => _isAnimationActive = true;

    [UsedImplicitly] // TODO: надо назначить на кнопкИ активации этого слайда
    public void StopExample()
    {
        gameObject.SetActive(false);
        _sphere.SetActive(false);
        _enemy.SetActive(false);
    }

    private void RefreshExample()
    {
        StartCoroutine(SeeExample());
    }

    private IEnumerator SeeExample()
    {
        transform.position = _startCubePosition;
        transform.GetComponent<MeshRenderer>().material = _startMaterial;
        _sphere.SetActive(true);
        _enemy.SetActive(true);

        yield return new WaitForSeconds(1);

        _isAnimationActive = true;
    }
}
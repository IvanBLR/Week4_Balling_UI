using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager _gameManager;
    private GameObject _ball;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            var color = transform.GetComponent<MeshRenderer>().material.color;
            otherCollider.GetComponent<MeshRenderer>().material.color = color;
            _gameManager.OnPlayerTouchedSphereEvent += SetNewPositionAndColor;
            _gameManager.GenerateNewPositionAndColor();
            _gameManager.ResetPlayerColor(color);
        }
    }

    public void Initialize(GameObject ballPrefab, Vector3 position, Color color)
    {
        _ball = Instantiate(ballPrefab);
        _ball.transform.position = position;
        _ball.GetComponent<MeshRenderer>().material.color = color;
    }

    public void HideBall()
    {
        _ball.SetActive(false);
    }

    private void SetNewPositionAndColor(Vector3 position, Color color)
    {
        transform.position = position;
        transform.GetComponent<MeshRenderer>().material.color = color;
        _gameManager.OnPlayerTouchedSphereEvent -= SetNewPositionAndColor;
    }
}
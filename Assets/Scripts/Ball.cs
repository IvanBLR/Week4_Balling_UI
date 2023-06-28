using UnityEngine;
public class Ball : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void Initialize(GameObject ballPrefab, Vector3 position, Color color)
    {
        var ball = Instantiate(ballPrefab);
        ball.transform.position = position;
        ball.GetComponent<MeshRenderer>().material.color = color;
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
    private void SetNewPositionAndColor(Vector3 position, Color color)
    {
        transform.position = position;
        transform.GetComponent<MeshRenderer>().material.color = color;
        _gameManager.OnPlayerTouchedSphereEvent -= SetNewPositionAndColor;
    }
}

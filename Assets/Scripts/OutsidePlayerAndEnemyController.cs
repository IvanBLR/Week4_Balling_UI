using UnityEngine;

public class OutsidePlayerAndEnemyController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.transform.SetPositionAndRotation(new Vector3(0, 0.5f, 0), Quaternion.identity);
            collision.transform.GetComponent<Rigidbody>().Sleep();
        }
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}

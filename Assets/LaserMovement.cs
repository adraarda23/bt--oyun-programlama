using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

      
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
}

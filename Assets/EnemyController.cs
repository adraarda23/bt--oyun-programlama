using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Vector2.down * Time.deltaTime);
        if (transform.position.y < -5f)
            Respawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Debug.Log("Lazer hit");
            Destroy(other.gameObject);
            Respawn();
        }
        else if (other.tag == "Player")
        {
            Debug.Log("Player hit");
            //Destroy(other.gameObject);
            Respawn();
            //call Damage function from PlayerController
            PlayerController player = other.GetComponent<PlayerController>();
            player.Damage();
        }
        else
        Debug.Log("Hit: " + other.tag);
        
    }

    void Respawn()
    {
        transform.position = new Vector2(Random.Range(-15f, 15f), 7f);
    }
}

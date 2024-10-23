using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 0.33f;
    private float nextFire = 0f;

[SerializeField]
    private float mvSpeed = 5f;
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(new Vector3(1, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime * mvSpeed);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * Time.deltaTime * mvSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            FireLaser();
            increaseNextFire();
        }
    }

    void FireLaser()
    {
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
    void increaseNextFire(){
        nextFire += fireRate;
    }

[SerializeField]
    private int lives = 3;
    public void Damage()
    {
        lives--;
        // set pos 0 0 0
        transform.position = Vector3.zero;
        if (lives < 1)
        {
            Destroy(gameObject);
        }
    }
}

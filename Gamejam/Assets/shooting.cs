
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform[] firePoint;
    public GameObject bulletPrefab;

    public float bulletForce;
    public int pelletcount = 5;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    private void shoot()
    {
        for (int i = 0; i < pelletcount; i++)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint[i].position, firePoint[i].rotation);
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint[i].up * bulletForce, ForceMode2D.Impulse);
        }
        


    }
}

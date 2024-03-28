using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Laser;
    public GameObject Cannon;
    public GameObject BulletsParent;
    public float BulletSpeed = 1.0f;
    public float ShootingRate = 1.0f;
    public GameObject LaserParent;
    public float destroyXPosition = 9f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bulletCopy = Instantiate(Bullet);
        bulletCopy.transform.parent = BulletsParent.transform;
        bulletCopy.transform.position = Cannon.transform.position;

        Vector2 bulletDirection = (transform.eulerAngles.y == 180 ? Vector2.left : Vector2.right); // Détermine la direction de la balle en fonction de la rotation du joueur
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(bulletDirection * BulletSpeed);

        RaycastHit2D hit = Physics2D.Raycast(Cannon.transform.position, bulletDirection);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            
        }
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Destroy(hit.collider.gameObject);
        }

        StartCoroutine(DestroyBulletAtLimit(bulletCopy)); 
    }


    IEnumerator DestroyBulletAtLimit(GameObject bullet)
    {
        while (true)
        {
            yield return null;
            if (bullet.transform.position.x >= destroyXPosition || bullet.transform.position.x <= -destroyXPosition)
            {
                Destroy(bullet);
                yield break;
            }
        }
    }
}

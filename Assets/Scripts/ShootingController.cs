using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Cannon;
    public GameObject BulletsParent;
    public float BulletSpeed = 1.0f;
    public float ShootingRate = 1.0f;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletCopy = Instantiate(Bullet);
            bulletCopy.transform.parent = BulletsParent.transform;
            bulletCopy.transform.position = Cannon.transform.position;
            // TODO: ne pas avoir "(transform.eulerAngles.y == 180 ? -1 : 1)" et shooter selon la direction pointe
            bulletCopy.GetComponent<Rigidbody2D>().AddForce(new Vector2((transform.eulerAngles.y == 180 ? -1 : 1) * BulletSpeed, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
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

    // Start is called before the first frame update
    void Start()
    { 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletCopy = Instantiate(Bullet);
            bulletCopy.transform.parent = BulletsParent.transform;
            bulletCopy.transform.position = Cannon.transform.position;
            // TODO: ne pas avoir "(transform.eulerAngles.y == 180 ? -1 : 1)" et shooter selon la direction pointe
            bulletCopy.GetComponent<Rigidbody2D>().AddForce(new Vector2((transform.eulerAngles.y == 180 ? -1 : 1) * BulletSpeed, 0));
            RaycastHit2D hit = Physics2D.Raycast(new(Cannon.transform.position.x, Cannon.transform.position.y), Mathf.Abs(transform.rotation.y) == 1 ? Vector2.left : Vector2.right);

            if (hit.collider != null && hit.collider.tag == "Enemie")
            {
                GameObject copieLaser = Instantiate(Laser, LaserParent.transform);
                copieLaser.transform.position = Cannon.transform.position;
                copieLaser.GetComponent<LineRenderer>().SetPosition(1, hit.collider.transform.position);

                copieLaser.GetComponent<LineRenderer>().enabled = true;

                Destroy(hit.collider.gameObject);
            }
        }
    }
}
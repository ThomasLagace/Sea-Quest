using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Cannon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        RaycastHit2D hit = Physics2D.Raycast(new(Cannon.transform.position.x, Cannon.transform.position.y), Mathf.Abs(transform.rotation.y) == 1 ? Vector2.left : Vector2.right);

        if (hit.collider != null && hit.collider.tag == "Enemie")
        {
            GameObject copieLaser = Instantiate(Laser);
            copieLaser.transform.position = Cannon.transform.position;
            copieLaser.GetComponent<LineRenderer>().SetPosition(1, hit.collider.transform.position);
        }
    }
}

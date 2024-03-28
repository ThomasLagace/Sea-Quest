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
        Vector2 rayOrigin = new Vector2(Cannon.transform.position.x, Cannon.transform.position.y);
        Vector2 rayDirection = Mathf.Abs(transform.rotation.y) == 1 ? Vector2.left : Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            GameObject copieLaser = Instantiate(Laser);
            copieLaser.transform.position = Cannon.transform.position;
            LineRenderer lineRenderer = copieLaser.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, Cannon.transform.position);
            lineRenderer.SetPosition(1, hit.point);
            Destroy(hit.collider.gameObject);
        }
    }
}

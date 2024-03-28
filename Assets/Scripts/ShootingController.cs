using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Cannon;
    public GameObject LaserParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

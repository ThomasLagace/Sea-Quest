using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 20.0f;
    public float MaxY = 3.0f;
    public float MinY = -4.0f;
    public float MaxMinX = 7.0f;
    public GameObject BulletsParent;
    public int NombreDePlongeur = 0;
    public int MaxPlongeur = 5;
    public ScoreHandler ScoreHandler;
    public int Vies = 5;
    //added
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new();
        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.down;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180.0f, transform.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0.0f, transform.eulerAngles.z);
        }

        Vector3 nextPosition = transform.position + Speed * Time.deltaTime * direction.normalized;

        nextPosition.x = Mathf.Min(nextPosition.x, MaxMinX);
        nextPosition.x = Mathf.Max(nextPosition.x, -MaxMinX);

        nextPosition.y = Mathf.Min(nextPosition.y, MaxY);
        nextPosition.y = Mathf.Max(nextPosition.y, MinY);

        transform.position = nextPosition;
        // BulletsParent.transform.position = transform.position;
        //added
        if (canMove == false)
        {
            Speed = 0f;
            return;
        }
        if (canMove == true)
        {
            Speed = 6f;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifiez si le gameObject en collision est le sous-marin
        if (collision.CompareTag("Enemy"))
        {
            // R�initialisez la sc�ne
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.CompareTag("Plongeur"))
        {
            if (NombreDePlongeur >= MaxPlongeur)
                return;
            NombreDePlongeur++;
            Destroy(collision.gameObject);
        }
    }
}
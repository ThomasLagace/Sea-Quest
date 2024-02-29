using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 1f;
    public float MaxHeight = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new();
        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.up;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.left;
        if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.down;
        if (Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.right;

        Vector3 nextPosition = transform.position + direction.normalized * Speed * Time.deltaTime;

        nextPosition.y = Mathf.Min(nextPosition.y, MaxHeight);

        transform.position = nextPosition;
    }
}

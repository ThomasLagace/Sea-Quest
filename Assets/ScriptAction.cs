using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GameObject.Find("Balle");
            GameObject balleCopie = Instantiate(GameObject.Find("Bullet"));
            balleCopie.GetComponent<SpriteRenderer>().enabled = true;
            balleCopie.transform.position = new Vector3(0, 0, 0); //Positionner
        }
    }

}

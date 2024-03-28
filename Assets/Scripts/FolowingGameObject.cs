using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingGameObject : MonoBehaviour
{
    public GameObject GameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{

    public float speed = 0.1f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) *speed * Time.deltaTime);

    }
    
    
}


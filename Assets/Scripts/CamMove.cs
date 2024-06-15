using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y, transform.position.z);
    }

    //public Transform target;
    //public float smoothSpeed = 0.125f;
    //public Vector3 offset;

    //void LateUpdate()
    //{
    //    Vector3 desiredPosition = target.position + offset;
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}
}

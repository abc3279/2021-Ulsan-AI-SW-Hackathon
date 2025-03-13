using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    public GameObject user;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(user.transform.position.x, transform.position.y, user.transform.position.z);
        this.transform.LookAt(targetPosition);


    }
}

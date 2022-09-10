using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isTouched;
    public GameObject destroyObj;

    private Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
            isTouched = false;
        targetpos = transform.position;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            destroyObj = other.gameObject;
            isTouched = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Sin(Time.time) * 5.0f + targetpos.x, targetpos.y, targetpos.z);
        if (isTouched)
        {
                Destroy(destroyObj);
        }

        float dx = Input.GetAxis("Horizontal") * 0.1f;
        float dz = Input.GetAxis("Vertical") * 0.1f;
        transform.position = new Vector3(
            transform.position.x + dx, 0, transform.position.z + dz
        );
    }
}



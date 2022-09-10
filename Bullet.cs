using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public bool isTouched;
    public GameObject destroyObj;

    private bool emitted_ = false;

    void Start()
    {
        isTouched = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Enemy")
        {
            destroyObj = other.gameObject;
            isTouched = true;
        }
    }

    public void emit(Vector3 startPos)
	{
		transform.position = startPos;
		emitted_ = true;
	}

	// Update is called once per frame
	void Update()
	{
        if (isTouched)
        {
            {
                Destroy(destroyObj);
            }
        }

        float dx = Input.GetAxis("Horizontal") * 0.1f;
        float dz = Input.GetAxis("Vertical") * 0.1f;
        transform.position = new Vector3(
            transform.position.x + dx, 0, transform.position.z + dz
        );
        if (emitted_)
		{
			var pos = transform.position;
			pos.z += 1.0f;
			transform.position = pos;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MovingBox")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if (Mathf.Abs(distance) < 0.5f)
            {
                Rigidbody box = other.GetComponent<Rigidbody>();
                if (box)
                {
                    box.isKinematic = true;
                }

                MeshRenderer renderer = GetComponentInChildren<MeshRenderer>();
                if (renderer)
                {
                    renderer.material.color = Color.blue;
                }

                Destroy(this);
            }
        }
    }
}

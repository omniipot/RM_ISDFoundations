using UnityEngine;

public class Raycast : MonoBehaviour
{
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 20f))
        {
            Debug.Log("Hit: " + hitInfo.collider.name);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
        }
        else
        {
            Debug.Log("No hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.red);
        }
    }
}

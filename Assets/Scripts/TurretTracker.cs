using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5;
    void Update()
    {
        Vector3 lookingATtarget = (target.position - transform.position).normalized;
        if (lookingATtarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookingATtarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        float dotProduct = Vector3.Dot(transform.forward, lookingATtarget);

        if (dotProduct > 0.95)
        {
            Debug.Log("Target Locked on!");
        }
        else
        {
            Debug.Log("Searching...");
        }
    }
}

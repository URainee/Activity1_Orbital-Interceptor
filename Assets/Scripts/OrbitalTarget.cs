using UnityEngine;
using UnityEngine.UIElements;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA, pointB;
    public float travelDuration;

    public SphereCollider hitbox;

    private float timer;
    private bool toPointB = true;

    public MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / travelDuration;

        Vector3 start = toPointB ? pointA.position : pointB.position;
        Vector3 target = toPointB ? pointB.position : pointA.position;

        transform.position = Vector3.Lerp(start, target, t);

        if (t > 1f)
        {
            timer = 0;
            toPointB = !toPointB;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.AddScore(10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.DeductScore(10);
    }

    private void OnMouseDown()
    {
        Debug.Log("10+ Points");
        mr.material.color = Color.red;
    }
}

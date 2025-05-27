using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Attractor : MonoBehaviour
{
    [Tooltip("Strength of the force pulling the nucleons toward the origin.")]
    public float attractionForce = 10f;

    public float settleTime = 3f;
    float startTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        Vector3 directionToCenter = -transform.position; // Toward (0,0,0)
        float distance = directionToCenter.magnitude;

        float elapsedTime = Time.time - startTime;

        Vector3 force = directionToCenter.normalized * attractionForce;
        rb.AddForce(force, ForceMode.Acceleration);
    }
}

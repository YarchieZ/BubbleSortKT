using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speedThreshold;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color highlightColor;
    [SerializeField] private Material ballMaterial;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_rb.linearVelocity.y) < speedThreshold)
        {
            ballMaterial.color = highlightColor;
        }
        else
        {
            ballMaterial.color = defaultColor;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

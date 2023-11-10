using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6f;
    new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        Matrix4x4 isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
        Vector3 normalizedInput = isoMatrix.MultiplyPoint3x4(input);
        rigidbody.velocity = normalizedInput * speed;
    }

    void movementForKeyboard()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rigidbody.velocity = new Vector3(xMove, 0f, zMove) * speed;
    }
}

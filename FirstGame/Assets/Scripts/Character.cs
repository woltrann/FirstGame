using UnityEngine;

public class Characher : MonoBehaviour
{
    private Rigidbody karakterRb;
    private Animator karakterAnim;
   

    public float forwardSpeed = 5f; // �leri h�z
    public float sideSpeed = 5f;    // Sa�-Sol h�z

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        Debug.Log("Sola d�nd�");
        transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        Debug.Log("Sa�a d�nd�");
        transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
    }
}

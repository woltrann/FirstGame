using UnityEngine;

public class Characher : MonoBehaviour
{
    private Rigidbody karakterRb;
    private Animator karakterAnim;
   

    public float forwardSpeed = 5f; // Ýleri hýz
    public float sideSpeed = 5f;    // Sað-Sol hýz

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * forwardSpeed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        Debug.Log("Sola döndü");
        transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
    }

    public void MoveRight()
    {
        Debug.Log("Saða döndü");
        transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
    }
}

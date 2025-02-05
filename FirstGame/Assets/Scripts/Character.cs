using UnityEngine;

public class Characher : MonoBehaviour
{
    private Rigidbody karakterRb;
    public float sideSpeed = 5f;
    private bool moveRight = false;
    private bool moveLeft = false;

    void Update()
    {
        if (moveRight) MoveCharacter(Vector3.forward);
        if (moveLeft) MoveCharacter(Vector3.back);
    }
    private void MoveCharacter(Vector3 direction)
    {
        float newXPosition = transform.position.z + direction.z * sideSpeed * Time.deltaTime;
        newXPosition = Mathf.Clamp(newXPosition, -5, 5);
        transform.position = new Vector3(transform.position.x,transform.position.y, newXPosition  );
    }
    public void OnRightButtonDown() => moveRight = true;
    public void OnRightButtonUp() => moveRight = false;
    public void OnLeftButtonDown() => moveLeft = true;
    public void OnLeftButtonUp() => moveLeft = false;
}

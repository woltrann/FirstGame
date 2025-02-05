using UnityEngine;
using UnityEngine.UI;


public class ObjectMovement : MonoBehaviour
{
    public int speed;
    public bool move=false;

    void Update()
    {
        if (move) 
        { 
            Move();

        }
    }
    public void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
    public void StartGame()
    {
        move = true;
    }
}

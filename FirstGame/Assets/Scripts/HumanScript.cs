using UnityEngine;

public class HumanScript : MonoBehaviour
{
    private Animator animator;
    public int speed;
    public bool move = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (move) transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kontrol ettiðin karakterin tag'ýný Player yap
        {
            animator.SetBool("IsTouched", true);
            Destroy(gameObject);
        }
    }


}

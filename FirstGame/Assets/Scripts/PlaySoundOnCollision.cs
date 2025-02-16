using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource audioSource;
    public string targetTag = "Trap"; // Hedef nesnenin etiketi

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag)) // Yaln�zca belirli etiketli nesneyle �arp���nca
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
                
            }
        }
    }
}

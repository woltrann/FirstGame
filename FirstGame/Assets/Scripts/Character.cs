using UnityEngine;
using System.Collections;
using TMPro.Examples;


public class Character : MonoBehaviour
{
    private Rigidbody karakterRb;
    public float sideSpeed = 5f;
    private bool moveRight = false;
    private bool moveLeft = false;
    public GameObject[] traps;
  
    void FixedUpdate()
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

    public void SpawnTraps() => StartCoroutine(Spawn());
    public IEnumerator Spawn()
    {
        while (true)
        {

            Vector3 spawnPosition = new Vector3(-230, 2.5f, Random.Range(-2.5f, 2.5f));
            int randomTrapIndex = Random.Range(0, traps.Length); // Rasgele tuzak seçimi
            Instantiate(traps[randomTrapIndex], spawnPosition, Quaternion.identity);

            // Spawnlama aralýðýný belirle
            float spawnInterval = Random.Range(2f, 4f);

            // Verilen süre kadar bekle
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

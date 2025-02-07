using UnityEngine;
using System.Collections;
using TMPro.Examples;
using Unity.VisualScripting;
public class Character : MonoBehaviour
{
    private Rigidbody karakterRb;
    public float sideSpeed = 5f;
    private bool moveRight = false;
    private bool moveLeft = false;
    public GameObject[] traps;
    public GameObject[] forests;
    public GameObject[] humans;
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
            float spawnInterval = Random.Range(2f, 4f);     // Spawnlama aralýðýný belirle
            yield return new WaitForSeconds(spawnInterval);     // Verilen süre kadar bekle

            float zPosition = Random.Range(0,2) == 0 ? 11f : -11f;
            Vector3 spawnPosition2 = new Vector3(-230, 2.4f, zPosition);
            int randomForestsIndex=Random.Range(0, forests.Length);
            Instantiate(forests[randomForestsIndex], spawnPosition2, Quaternion.identity);
            float spawnInterval2 = Random.Range(1f, 2f);
            yield return new WaitForSeconds(spawnInterval2);

            int randomHumanIndex = Random.Range(0, humans.Length); 
            Instantiate(humans[randomHumanIndex], spawnPosition, Quaternion.identity);
            float spawnInterval3 = Random.Range(1f, 3f);     
            yield return new WaitForSeconds(spawnInterval3);     
        } 
    }
}

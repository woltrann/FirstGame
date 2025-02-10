using UnityEngine;
using System.Collections;
using TMPro.Examples;
using Unity.VisualScripting;
public class Character : MonoBehaviour
{
    public ParticleSystem Buff;
    public ParticleSystem Debuff;
    public float sideSpeed = 5000f; //5000 yaptým inspectorden 5000 olarak düzeltilecek
    public float smoothFactor = 0.2f; //eklendi
    private float targetZPosition; //eklendi
    private Vector3 velocity = Vector3.zero; //eklendi
    public GameObject[] traps;
    public GameObject[] forests;
    public GameObject[] humans;

    void Update() //eklendi
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            targetZPosition = Mathf.Clamp(transform.position.z + mouseX * sideSpeed * Time.deltaTime, -5, 5);
        }

        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, targetZPosition);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothFactor);
    }

    public void SpawnObject()
    {
        StartCoroutine(SpawnTraps());
        StartCoroutine(SpawnTrees());
        StartCoroutine(SpawnHuman());
    }
    private IEnumerator SpawnTraps()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(-230, 2.5f, Random.Range(-2.5f, 2.5f));
            int randomTrapIndex = Random.Range(0, traps.Length); // Rasgele tuzak seçimi
            Instantiate(traps[randomTrapIndex], spawnPosition, Quaternion.identity);
            float spawnInterval = Random.Range(2f, 4f);     // Spawnlama aralýðýný belirle
            yield return new WaitForSeconds(spawnInterval * MainControl.x);     // Verilen süre kadar bekle
            //Debug.Log("x Deðeri: " + MainControl.x);
        }
    }
    private IEnumerator SpawnTrees()
    {
        while (true)
        {
            float zPosition = Random.Range(0, 2) == 0 ? 13f : -11f;
            Vector3 spawnPosition2 = new Vector3(-230, 2.4f, zPosition);
            int randomForestsIndex = Random.Range(0, forests.Length);
            Instantiate(forests[randomForestsIndex], spawnPosition2, Quaternion.identity);
            float spawnInterval2 = Random.Range(1f, 2f);
            yield return new WaitForSeconds(spawnInterval2 * MainControl.x);
        }
    }
    private IEnumerator SpawnHuman()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(-230, 2.5f, Random.Range(-2.5f, 2.5f));
            int randomHumanIndex = Random.Range(0, humans.Length);
            Instantiate(humans[randomHumanIndex], spawnPosition, Quaternion.identity);
            float spawnInterval3 = Random.Range(2f, 3f);
            yield return new WaitForSeconds(spawnInterval3 * MainControl.x);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            Debuff.Stop();
            Debuff.Clear();
            Buff.Stop();
            Buff.Clear();
            Buff.Play();
        }
        if (other.CompareTag("Trap"))
        {
            Buff.Stop();
            Buff.Clear();
            Debuff.Stop();
            Debuff.Clear();
            Debuff.Play();
        }
    }
}

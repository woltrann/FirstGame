using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CannonContent : MonoBehaviour
{
    public ScrollRect scrollRect; // Scroll View
    public Transform content; // Scroll içindeki Content (Toplar burada)

    public Image[] materialIcons; // 6 adet malzeme ikonu
    public TextMeshProUGUI[] materialTexts;  // 6 adet malzeme miktarý

    public List<BallData> ballList; // Her top için malzeme listesi

    private int currentIndex = 0;
    private int totalBalls;
    private bool isLerping = false;

    void Start()
    {
        totalBalls = content.childCount; // Top sayýsýný al
        UpdateMaterials(0); // Ýlk top için malzemeleri ayarla
    }

    void Update()
    {
        if (!isLerping)
        {
            float normalizedPosition = scrollRect.horizontalNormalizedPosition;
            int newIndex = Mathf.RoundToInt(normalizedPosition * (totalBalls - 1));

            if (newIndex != currentIndex)
            {
                StartCoroutine(SmoothScroll(newIndex));
                UpdateMaterials(newIndex); // Malzemeleri güncelle
            }
        }
    }

    IEnumerator SmoothScroll(int targetIndex)
    {
        isLerping = true;
        currentIndex = targetIndex;

        float targetPosition = (float)currentIndex / (totalBalls - 1);
        float duration = 0.2f;
        float elapsedTime = 0;
        float startPosition = scrollRect.horizontalNormalizedPosition;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(startPosition, targetPosition, elapsedTime / duration);
            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPosition;
        isLerping = false;
    }

    void UpdateMaterials(int ballIndex)
    {
        BallData ball = ballList[ballIndex];

        for (int i = 0; i < materialIcons.Length; i++)
        {
            if (i < ball.materials.Count)
            {
                materialIcons[i].sprite = ball.materials[i].icon;
                materialTexts[i].text = ball.materials[i].amount.ToString();
                materialIcons[i].gameObject.SetActive(true);
                materialTexts[i].gameObject.SetActive(true);
            }
            else
            {
                materialIcons[i].gameObject.SetActive(false);
                materialTexts[i].gameObject.SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class BallData
{
    public string name;
    public List<MaterialRequirement> materials;
}

[System.Serializable]
public class MaterialRequirement
{
    public Sprite icon;
    public int amount;
}

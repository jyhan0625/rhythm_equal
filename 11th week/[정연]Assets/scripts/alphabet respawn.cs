using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    public GameObject[] alphabetPrefabs; // A, S, D ���ĺ� �̹��� ������ �迭
    public float spawnInterval = 1f; // ���ĺ� ���� �ֱ� (�� ����)
    private RectTransform canvasRectTransform; // Canvas�� RectTransform
    private float padding = 20f; // ȭ�� ��迡���� �е� ��

    void Start()
    {
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>(); // �θ� Canvas�� RectTransform ��������
        StartCoroutine(SpawnAlphabet());
    }

    IEnumerator SpawnAlphabet()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // ���� ���ĺ� ����
            GameObject alphabetPrefab = GetRandomAlphabetPrefab();

            // ���ο� ���ĺ� �̹��� ����
            GameObject newAlphabet = Instantiate(alphabetPrefab, transform);

            // ���� ��ġ ����
            RectTransform rectTransform = newAlphabet.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = GetRandomPosition(rectTransform.sizeDelta);

            // ����� �Է��� ��ٸ�
            yield return WaitForInput(newAlphabet);

            // ����ڰ� ���ĺ��� ������ �ʰ� �ð��� ������ ���ĺ� ����
            Destroy(newAlphabet);
        }
    }

    GameObject GetRandomAlphabetPrefab()
    {
        // A, S, D �� �����ϰ� ����
        int randomIndex = Random.Range(0, 3);
        return alphabetPrefabs[randomIndex];
    }

    Vector2 GetRandomPosition(Vector2 size)
    {
        float x = Random.Range(canvasRectTransform.rect.width - 2500, canvasRectTransform.rect.width - 1700);
        float y = Random.Range(canvasRectTransform.rect.height - 1500, canvasRectTransform.rect.height - 700);
        return new Vector2(x, y);
    }

    IEnumerator WaitForInput(GameObject alphabet)
    {
        bool keyPressed = false;
        while (!keyPressed)
        {
            if (Input.GetKeyDown(KeyCode.A) && alphabet.name == "A(Clone)")
            {
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && alphabet.name == "S(Clone)")
            {
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && alphabet.name == "D(Clone)")
            {
                keyPressed = true;
            }
            yield return null;
        }
    }
}

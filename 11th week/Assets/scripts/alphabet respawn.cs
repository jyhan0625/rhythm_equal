using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGame : MonoBehaviour
{
    public GameObject[] alphabetPrefabs; // A, S, D 알파벳 이미지 프리팹 배열
    public float spawnInterval = 1f; // 알파벳 생성 주기 (초 단위)
    private RectTransform canvasRectTransform; // Canvas의 RectTransform
    private float padding = 20f; // 화면 경계에서의 패딩 값

    void Start()
    {
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>(); // 부모 Canvas의 RectTransform 가져오기
        StartCoroutine(SpawnAlphabet());
    }

    IEnumerator SpawnAlphabet()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // 랜덤 알파벳 생성
            GameObject alphabetPrefab = GetRandomAlphabetPrefab();

            // 새로운 알파벳 이미지 생성
            GameObject newAlphabet = Instantiate(alphabetPrefab, transform);

            // 랜덤 위치 설정
            RectTransform rectTransform = newAlphabet.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = GetRandomPosition(rectTransform.sizeDelta);

            // 사용자 입력을 기다림
            yield return WaitForInput(newAlphabet);

            // 사용자가 알파벳을 누르지 않고 시간이 지나면 알파벳 제거
            Destroy(newAlphabet);
        }
    }

    GameObject GetRandomAlphabetPrefab()
    {
        // A, S, D 중 랜덤하게 선택
        int randomIndex = Random.Range(0, 3);
        return alphabetPrefabs[randomIndex];
    }

    Vector2 GetRandomPosition(Vector2 size)
    {
        float x = Random.Range(padding, canvasRectTransform.rect.width - size.x - padding);
        float y = Random.Range(padding, canvasRectTransform.rect.height - size.y - padding);
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

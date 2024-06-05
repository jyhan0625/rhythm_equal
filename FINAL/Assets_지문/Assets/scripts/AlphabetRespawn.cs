using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlphabetRespawn : MonoBehaviour
{
    public GameObject ring;
    public GameObject[] alphabetPrefabs; // A, S, D, J, K, L 프리팹들
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Heart;
    public GameObject ScoreObject;
    public GameObject Play;
    public GameObject Credit;
    public AudioSource MainAudio;
    public AudioSource PlayAudio;
    private RectTransform canvasRectTransform; // Canvas의 RectTransform
    private float padding = 20f; // 위치 패딩
    private Coroutine startCoroutine;
    private List<(GameObject, GameObject)> spawnedAlphabets = new List<(GameObject, GameObject)>(); // 스폰된 알파벳과 링을 저장할 리스트

    void OnEnable()
    {
        // 트리거가 true이면 코루틴 시작
        startCoroutine = StartCoroutine(SpawnAlphabet());
    }

    void OnDisable()
    {
        // 컴포넌트가 비활성화될 때 코루틴 중지
        if (startCoroutine != null)
        {
            StopCoroutine(startCoroutine);
            startCoroutine = null;
        }
    }

    void Start()
    {
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>(); // 부모 Canvas의 RectTransform 가져오기
    }

    IEnumerator SpawnAlphabet()
    {
        float[] spawnInterval = { 0.8f, 0.4f, 1.6f }; // bpm65에 맞춰서 박자 랜덤 생성

        while (true)
        {
            Debug.Log("go\n");
            yield return new WaitForSeconds(spawnInterval[Random.Range(0, 3)]);

            GameObject alphabetPrefab = GetRandomAlphabetPrefab();
            GameObject newAlphabet = Instantiate(alphabetPrefab, transform);
            GameObject newRing = Instantiate(ring, transform);

            RectTransform rectTransform = newAlphabet.GetComponent<RectTransform>();
            RectTransform ringRectTransform = newRing.GetComponent<RectTransform>();
            Vector2 spawnPosition = GetRandomPosition(rectTransform.sizeDelta);

            rectTransform.anchoredPosition = spawnPosition;
            ringRectTransform.anchoredPosition = spawnPosition;

            Destroy destroy = newAlphabet.GetComponent<Destroy>();
            destroy.enabled = true;

            spawnedAlphabets.Add((newAlphabet, newRing));
            StartCoroutine(AnimateRing(newRing));
        }
    }

    IEnumerator AnimateRing(GameObject ring)
    {
        RectTransform rectTransform = ring.GetComponent<RectTransform>();
        Vector3 originalScale = rectTransform.localScale;
        float animationDuration = 1.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < animationDuration)
        {
            float t = elapsedTime / animationDuration;
            rectTransform.localScale = Vector3.Lerp(originalScale * 1.5f, originalScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.localScale = originalScale; // 원래 크기로 되돌리기

        // 링이 원래 크기로 돌아간 후에 즉시 삭제
        Destroy(ring);
    }

    void Update()
    {
        if (spawnedAlphabets.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CheckInput("A");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                CheckInput("S");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CheckInput("D");
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                CheckInput("J");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                CheckInput("K");
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                CheckInput("L");
            }
        }
    }

    void CheckInput(string expectedKey)
    {
        if (spawnedAlphabets.Count > 0)
        {
            var (alphabet, ring) = spawnedAlphabets[0]; // 가장 먼저 생성된 알파벳과 링 선택

            // 사용자 입력 처리 로직
            if (alphabet.name.StartsWith(expectedKey))
            {
                Score.text = (int.Parse(Score.text) + 1).ToString();
            }
            else
            {
                if (int.Parse(Heart.text) == 1)
                {
                    Heart.text = "5";
                    DeActivate();
                }
                else
                {
                    Heart.text = (int.Parse(Heart.text) - 1).ToString();
                }
            }

            // 리스트에서 사용된 알파벳 제거 및 삭제
            spawnedAlphabets.RemoveAt(0);
            Destroy(alphabet);
        }
    }

    GameObject GetRandomAlphabetPrefab()
    {
        int randomIndex = Random.Range(0, alphabetPrefabs.Length);
        return alphabetPrefabs[randomIndex];
    }

    Vector2 GetRandomPosition(Vector2 size)
    {
        float x = Random.Range(canvasRectTransform.rect.width - 2300, canvasRectTransform.rect.width - 1000);
        float y = Random.Range(canvasRectTransform.rect.height - 1300, canvasRectTransform.rect.height - 600);
        return new Vector2(x, y);
    }

    public void Activate()
    {
        this.enabled = true;
        ScoreObject.SetActive(true);
        Play.SetActive(false);
        Credit.SetActive(false);
        MainAudio.Stop();
        PlayAudio.Play();
        Debug.Log("AlphabetRespawn has been activated!");
    }

    public void DeActivate()
    {
        this.enabled = false;
        if (startCoroutine != null)
        {
            StopCoroutine(startCoroutine);
            startCoroutine = null;
        }
        ScoreObject.SetActive(false);
        Play.SetActive(true);
        Credit.SetActive(true);
        MainAudio.Play();
        PlayAudio.Stop();
        Debug.Log("AlphabetRespawn has been deactivated!");
    }
}

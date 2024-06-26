﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class AlphabetRespawn : MonoBehaviour
{
    public GameObject[] alphabetPrefabs; // A, S, D ���ĺ� �̹��� ������ �迭
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Heart;
    public GameObject ScoreObject;
    public GameObject Play;
    public GameObject Credit;
    public AudioSource MainAudio;
    public AudioSource PlayAudio;
    private RectTransform canvasRectTransform; // Canvas�� RectTransform
    private float padding = 20f; // ȭ�� ��迡���� �е� ��
    private Coroutine startCoroutine;
    private GameObject newAlphabet;
    private Destroy destroy;
    private float startTime;

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
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>(); // �θ� Canvas�� RectTransform ��������
    
    }

    IEnumerator SpawnAlphabet()
    {
        float[] spawnInterval = { 0.8f, 0.8f / 2, 0.8f * 2 }; //bpm65에 맞춰서 박자 랜덤 생성

        while (true)
        {

            Debug.Log("go\n");
            yield return new WaitForSeconds(spawnInterval[Random.Range(0,3)]);

            // ���� ���ĺ� ����
            GameObject alphabetPrefab = GetRandomAlphabetPrefab();

            // ���ο� ���ĺ� �̹��� ����
            newAlphabet = Instantiate(alphabetPrefab, transform);

            // ���� ��ġ ����
            RectTransform rectTransform = newAlphabet.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = GetRandomPosition(rectTransform.sizeDelta);

            destroy = newAlphabet.GetComponent<Destroy>();
            destroy.enabled = true;
            // ����� �Է��� ��ٸ�

            yield return WaitForInput(newAlphabet);

            // ����ڰ� ���ĺ��� ������ �ʰ� �ð��� ������ ���ĺ� ����
            Destroy(newAlphabet);
        }
    }

    GameObject GetRandomAlphabetPrefab()
    {
        // A, S, D �� �����ϰ� ����
        int randomIndex = Random.Range(0, 6);
        return alphabetPrefabs[randomIndex];
    }

    Vector2 GetRandomPosition(Vector2 size)
    {
        float x = Random.Range(canvasRectTransform.rect.width - 2300, canvasRectTransform.rect.width - 1000);
        float y = Random.Range(canvasRectTransform.rect.height - 1300, canvasRectTransform.rect.height - 600);
        return new Vector2(x, y);
    }

    IEnumerator WaitForInput(GameObject alphabet)
    {

        bool keyPressed = false;
        while (!keyPressed)
        {


            if (alphabet == null) keyPressed = true;


            if (Input.GetKeyDown(KeyCode.A))
            {
                // A 키 입력 시
                if (alphabet.name == "A(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                // S 키 입력 시
                if (alphabet.name == "S(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                // D 키 입력 시
                if (alphabet.name == "D(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.J)) // 추가: J 키 입력 시
            {
                if (alphabet.name == "J(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.K)) // 추가: K 키 입력 시
            {
                if (alphabet.name == "K(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }
            else if (Input.GetKeyDown(KeyCode.L)) // 추가: L 키 입력 시
            {
                if (alphabet.name == "L(Clone)") Score.text = (int.Parse(Score.text) + 1).ToString();
                else
                {

                    if (int.Parse(Heart.text) == 1)
                    {
                        Heart.text = "5";
                        Destroy(newAlphabet);
                        DeActivate();
                    }

                    else Heart.text = (int.Parse(Heart.text) - 1).ToString();


                }
                keyPressed = true;
            }

            yield return null;
        }

        yield return null;
    }


    public void Activate()
    {
        this.enabled = true;
        Debug.Log("AlphabetRespawn has been activated!");
    }

    public void DeActivate()
    {
        this.enabled = false;
        ScoreObject.SetActive(false);
        Play.SetActive(true);
        Credit.SetActive(true);
        MainAudio.Play();
        PlayAudio.Stop();
        Debug.Log("AlphabetRespawn has been deactivated!");
    }
}

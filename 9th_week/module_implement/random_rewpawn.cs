using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public Camera mainCamera; // 카메라 참조 변수
    public GameObject[] shapes; // 도형 프리팹 

    private GameObject shapeObject1; // 첫 번째 도형 
    private GameObject shapeObject2; // 두 번째 도형 
    private bool isShape1Active = true; // 활성화된 도형 추적 변수

    // Start 함수에서 1초마다 SpawnRandomShapes() 함수를 호출하여 도형을 생성 또는 삭제
    void Start()
    {
        InvokeRepeating("SpawnOrDestroyShape", 0f, 1f);
    }

    // 1초마다 호출되는 함수로, 도형을 생성하거나 삭제함
    void SpawnOrDestroyShape()
    {
        // 카메라의 시야 정보 가져오기
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // 현재 활성화된 도형 삭제
        if (isShape1Active && shapeObject1 != null)
        {
            Destroy(shapeObject1);
        }
        else if (!isShape1Active && shapeObject2 != null)
        {
            Destroy(shapeObject2);
        }

        // 새로운 도형 생성 위치 계산
        float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
        float randomY = Random.Range(-cameraHeight / 2f, cameraHeight / 2f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        // 무작위 도형 선택
        GameObject randomShape = shapes[Random.Range(0, shapes.Length)];

        // 도형 생성
        if (isShape1Active)
        {
            shapeObject1 = Instantiate(randomShape, randomPosition, Quaternion.identity);
        }
        else
        {
            shapeObject2 = Instantiate(randomShape, randomPosition, Quaternion.identity);
        }

        // 다음에 생성될 도형을 설정
        isShape1Active = !isShape1Active;
    }
}

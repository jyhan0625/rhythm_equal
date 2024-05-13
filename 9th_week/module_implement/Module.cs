using System.Collections;
using UnityEngine;

public class MODULE1 : MonoBehaviour
{
    // 생성할 GameObject 프리팹 지정 -- Module.unity 씬에서의 Circle로 지정
    public GameObject objectPrefab;

    // 사라질 시간
    public float destroyDelay = 1f;

    void Start()
    {
        // SpawnObject 코루틴을 시작
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // 무작위 생성 간격을 계산
            float spawnInterval = Random.Range(1f, 5f);

            // 생성 간격만큼 대기
            yield return new WaitForSeconds(spawnInterval);

            // 무작위 생성 위치를 계산
            float x = Random.Range(-5.11f, 5.38f);
            float y = Random.Range(3.9f, -3.95f);

            // 오브젝트 프리팹을 무작위 위치에 생성
            GameObject newObject = Instantiate(objectPrefab, new Vector3(x, y, 0), Quaternion.identity);

            // 일정 시간이 지난 후
            yield return new WaitForSeconds(destroyDelay);

            // 생성된 오브젝트를 제거
            Destroy(newObject);
        }
    }
}

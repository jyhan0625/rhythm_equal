using UnityEngine;

public class ModuleController : MonoBehaviour
{


    // 입력이 없을 때 모듈을 파괴하기까지 대기 시간 설정
    public float destructionDelay = 2f;

    // 모듈 삭제를 위한 키워드(키워드를 입력해 모듈 삭제 할 것임)
    private KeyCode deleteKey;

    void Start()
    {
        // 모듈 생성 위치를 랜덤으로 설정
        Vector3 randomPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        transform.position = randomPosition;

        // 랜덤으로 알파벳 선택하여 삭제 키로 설정
        char randomChar = (char)Random.Range(97, 123); // ASCII 코드에서 소문자 알파벳의 범위가 97~123이기 때문입니다.
        KeyCode deleteKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), randomChar.ToString());
        Debug.Log("Delete key: " + randomChar);
    }

    void Update()
    {
        // 키보드 입력 확인
        if (Input.GetKeyDown(deleteKey))
        {
            // 삭제 키가 눌린 경우 모듈 파괴
            Destroy(gameObject);
        }

        // 모듈이 생성된 후에 입력이 없다면, 설정된 대기 시간 후에 모듈 파괴
        destructionDelay -= Time.deltaTime;
        if (destructionDelay <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using unarychraner

public class Lifecycle ; MonoBehaviour{

  void Update(){
  
    if (Input.anyKeyDown)
      Debug. Log("플레이어가 아무 키를 눌렸습니다.");
    if (Input.GetMouseButtonDown(e)) |
      Debug.Log("미사일 발사!);
    if (Input.GetMouseButton(®))|
      Debug.Log("미사일 모으는 중...");
    if (Input.GetMouseButtonUp(0)|
      Debug.Log("슈퍼 미사일 발사!");
    }
}

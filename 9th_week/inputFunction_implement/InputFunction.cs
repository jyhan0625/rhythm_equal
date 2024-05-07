using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    void Update()
    {
        // 아무 키 / 마우스 클릭에 반응
        if (Input.anyKeyDown) Debug.Log("키를 누를 때마다 true 반환 ");

        if (Input.anyKey) Debug.Log("키를 누르는 동안 true 반환 ");


        // 키보드 키에 반응
        if (Input.GetKeyDown(KeyCode.Return)) Debug.Log("Enter를 누를 때마다 true 반환 ");

        if (Input.GetKey(KeyCode.LeftArrow)) Debug.Log("왼쪽 화살표를 누르는 동안 true 반환 ");

        if (Input.GetKeyUp(KeyCode.RightArrow)) Debug.Log("오른쪽 화살표 누르는 것을 멈출 때 true 반환 ");


        // 마우스에 반응 : 매개변수 0 -> 왼쪽 버튼 / 매개변수 1 -> 오른쪽 버튼 
        if (Input.GetMouseButton(0)) Debug.Log("왼쪽 마우스를 누를 때마다 true 반환 ");

        if (Input.GetMouseButtonDown(0)) Debug.Log("왼쪽 마우스를 누르는 동안 true 반환 ");

        if (Input.GetMouseButtonUp(0)) Debug.Log("왼쪽 마우스를 누르는 것을 멈출 때 true 반환 ");

    }


}

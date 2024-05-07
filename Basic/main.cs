using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    void Start()
    {
        // 출력
        Debug.Log("Hello World");


        // 배열
        string[] name = { "a", "b", "c", "d" };

        int[] age = new int[3];
        age[0] = 0;
        age[1] = 1;
        age[2] = 2;


        // 리스트 선언
        List<string> adress = new List<string>();

        // 리스트 삽입
        adress.Add("경기도");
        adress.Add("서울시");

        // 리스트 삭제
        adress.RemoveAt(1);
        adress.RemoveAt(0);


        // 문자열 연산
        string newstr = "문자열" + "합치기";


        // 특수반복문
        string[] strings = { "하나씩", "참조해서", "반복", "파이썬 방식 중", "for i in list", "과 유사" };
        foreach (string each in strings) Debug.Log(each);


        //클래스 - 인스턴스화 (Person.cs 참고)
        Person Student_A = new Person();
        Student_A.Name = "Alex";
        Debug.Log(Student_A.IsSleeping());


        //상속 (Person.cs, Police.cs 참고)
        Police B = new Police();
        B.Name = "Luna";
        Debug.Log(B.HavingGun());


    }

}

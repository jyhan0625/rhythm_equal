using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public TextMeshProUGUI Heart;
    public GameObject canvas;

    float[] spawnInterval = { 0.8f * 2, 0.8f * 3, 0.8f * 4 };

    private AlphabetRespawn alphabetrespawn;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        yield return new WaitForSeconds(spawnInterval[Random.Range(0, 3)]);

        if (int.Parse(Heart.text) == 1)
        {
            Heart.text = "5";
            Destroy(this);
            alphabetrespawn = canvas.GetComponent<AlphabetRespawn>();
            alphabetrespawn.DeActivate();
            
        }

        else
        {

            Heart.text = (int.Parse(Heart.text) - 1).ToString();

        }


        Destroy(this.gameObject);




    }
}

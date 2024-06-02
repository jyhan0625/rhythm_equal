using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button triggerButton;
    public AlphabetRespawn alphabetRespawnScript;
    public GameObject canvasObject; // Canvas 객체 참조
    public GameObject Play;
    public GameObject Credit;
    public AudioSource MainAudio;
    public AudioSource PlayAudio;


    void Start()
    {
        if (triggerButton != null && canvasObject != null)
        {
            // 버튼에 클릭 이벤트 리스너 추가
            triggerButton.onClick.AddListener(OnButtonClicked);
        }
        else
        {
            Debug.LogError("Trigger button or Canvas object is not assigned.");
        }
    }

    void OnButtonClicked()
    {
        // AlphabetRespawn 스크립트 활성화

        alphabetRespawnScript.Activate();
        Destroy(Play);
        Destroy(Credit);
        MainAudio.Stop();
        PlayAudio.Play();

    }
}

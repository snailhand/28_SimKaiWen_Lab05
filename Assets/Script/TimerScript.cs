using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public bool timerActive;

    private TMP_Text timerText;
    private float currentTime;
    [SerializeField] int totalTime;

    private CharacterController playerController;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsController;

    void Start()
    {
        currentTime = totalTime;
        timerActive = true;
        timerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        var player = GameObject.Find("Player");
        playerController = player.GetComponent<CharacterController>();
        fpsController = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    void Update()
    {
        if(timerActive)
        {
            if (currentTime > 0)
            {
                UpdateTimerUI();
            }
            else
            {
                timerActive = false;
                playerController.enabled = false;
                fpsController.UnlockCursor();

                SceneHandler.inst.LoseScene();
            }
        }
    }

    private void UpdateTimerUI()
    {
        currentTime -= Time.deltaTime;

        //formatting minutes & seconds
        var min = Mathf.Floor(currentTime/ 60).ToString("00");
        var sec = (currentTime % 60).ToString("00");

        timerText.text = string.Format("Timer: {0}:{1}", min, sec);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    private int coinCount;
    private CharacterController playerController;
    [SerializeField] TMPro.TMP_Text coinText;

    public GameObject coinFx;
    public GameObject pickupFx;

    void Start()
    {
        coinCount = GameObject.Find("Coins").transform.childCount;
        playerController = GetComponent<CharacterController>();
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins Left: " + coinCount.ToString();
    }

    private void WinLoseCondition(bool state)
    {
        if(state)
            SceneHandler.inst.WinScene();
        else
            SceneHandler.inst.LoseScene();

        //stops player from moving//
        playerController.enabled = false;
        var timer = GameObject.Find("Timer").GetComponent<TimerScript>();
        timer.timerActive = false;
        
        var fpsController = transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpsController.UnlockCursor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coins"))
        {
            if (coinCount <= 1)
            {
                WinLoseCondition(true);
            }

            Destroy(other.gameObject);
            coinCount--;
            PlayParticleEffect(other.transform);

            UpdateCoinUI();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            WinLoseCondition(false);
        }
    }

    private void PlayParticleEffect(Transform coin)
    {
        var effect1 = Instantiate(coinFx, coin.position, Quaternion.Euler(90, 0, 0));
        var effect2 = Instantiate(pickupFx, coin.position, Quaternion.Euler(90, 0, 0));
        Destroy(effect1, 3);
        Destroy(effect2, 3);
    }
}

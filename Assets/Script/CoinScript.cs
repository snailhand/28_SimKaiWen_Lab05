using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private int coinCount;
    private CharacterController playerController;
    [SerializeField] TMPro.TMP_Text coinText;

    void Start()
    {
        coinCount = GameObject.Find("Coins").transform.childCount;
        playerController = GetComponent<CharacterController>();
        UpdateCoinUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Coins"))
        {
            if(coinCount <= 1)
            {
                WinCondition();
            }

            Destroy(other.gameObject);
            coinCount--;
            UpdateCoinUI();
        }
    }

    private void UpdateCoinUI()
    {
        coinText.text = "Coins Left: " + coinCount.ToString();
    }

    private void WinCondition()
    {
        SceneHandler.inst.WinScene();

        //stops player from moving//
        playerController.enabled = false;

        var fpsController = transform.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        fpsController.UnlockCursor();
    }
}

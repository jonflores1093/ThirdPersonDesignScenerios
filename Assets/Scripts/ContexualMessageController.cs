﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContexualMessageController : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;

        StartCoroutine(ShowMessage("Testing", 2));

    }

    private IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;
        yield return new WaitForSeconds(duration);
        canvasGroup.alpha = 0;


    }




}

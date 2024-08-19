using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float showDuration = .3f;

    void Start() {
        damageCanvas.enabled = false;
    }

    public void ShowDamageCanvas() {
        StartCoroutine(CR_ShowBlood());
    }

    IEnumerator CR_ShowBlood() {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(showDuration);
        damageCanvas.enabled = false;
    }
}

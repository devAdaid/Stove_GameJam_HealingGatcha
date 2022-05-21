using System.Collections;
using TMPro;
using UnityEngine;

public class FirstCollectEffectUI : UIBase
{
    [SerializeField]
    private TMP_Text lineText;
    [SerializeField]
    private new ParticleSystem particleSystem;

    private string plantId;

    public override void Initialize()
    {
        SetActive(false);
    }

    public void Play(string text, string plantId)
    {
        this.plantId = plantId;
        lineText.text = $"\"{text}\"";
        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        SetActive(true);
        yield return new WaitForSeconds(0.2f);
        GameSystem.I.Event.InvokeEvent(new OpenGachaResultUI(plantId));
        particleSystem.Play();
        yield return new WaitForSeconds(2.6f);
        SetActive(false);
    }
}

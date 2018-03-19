using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {
    private Image image;
    public float fadeInTime;
    private Color imageColor;

    public float fadeOutTime;
    public bool fadeIn;
    public bool fadeOut;



    private float imageAlpha;
    private float alphaChange;
    
    void Start () {
        image = GetComponent<Image>();
	}
	

    
	void Update () {

        if (fadeIn)
        {
            alphaChange += Time.deltaTime / fadeInTime;
            imageAlpha = Mathf.Lerp(1f, 0f, alphaChange);
            imageColor.a -= alphaChange;
            image.color = imageColor;
            if (alphaChange >= 1f)
            {
                alphaChange = 0;
                fadeIn = false;
                gameObject.SetActive(false);
            }
        }

        if(!fadeIn && fadeOut)
        {
            gameObject.SetActive(true);
            alphaChange += Time.deltaTime * fadeOutTime;
            imageAlpha = Mathf.Lerp(0f, 1f, alphaChange);
            imageColor.a += alphaChange;
            image.color = imageColor;
            if (imageAlpha >= 1) fadeIn = false;
        }
    }
}

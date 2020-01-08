using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LayoutCard : MonoBehaviour
{
    public Text textPrice;
    public Image preview;
    public Button button;
    public void Init(string text, Sprite preview)
    {
        textPrice.text = text;
        this.preview.sprite = preview;
    }
}

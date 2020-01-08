using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsLayout : MonoBehaviour
{
    public LayoutCard menuCardPrefab;

    public static BuildsLayout singleton;

    void Start()
    {
        if (singleton != null)
        {
            Destroy(gameObject);
            return;
        }
        singleton = this;

    }



    public void AddChildren(Sprite sprite, string text, System.Action buttonAction)
    {
        var menuCard = Instantiate(menuCardPrefab, transform);

        menuCard.preview.sprite = sprite;
        menuCard.textPrice.text = text;
        menuCard.button.onClick.RemoveAllListeners();
        menuCard.button.onClick.AddListener(buttonAction.Invoke);
    }


    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}

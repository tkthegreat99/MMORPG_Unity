using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class UI_Button : UI_Base
{ 
    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText
    }

    enum GameObjects
    {
        TestObjects,
    }

    enum Images
    {
        ItemIcon
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons)); 
        Bind<Text>(typeof(Texts));
        //Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
       
    }
    

    int _score = 0;
    public void OnButtonClicked()
    {
        _score++;

        GetText((int)Texts.ScoreText).text = $"score : {_score}";
    }
}

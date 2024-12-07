using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    [Range(0, 100)]
    public float Value;
    public float speed;

    public float margin;

    public RectTransform Center, Top, Bottom, Right, Left;
    void Start()
    {
        
    }
    void Update()
    {
        float TopValue, BottomValue, RightValue, LeftValue;

        TopValue = Mathf.Lerp(Top.position.y, Center.position.y + margin + Value, speed * Time.deltaTime);
        BottomValue = Mathf.Lerp(Bottom.position.y, Center.position.y - margin - Value, speed * Time.deltaTime);
        LeftValue = Mathf.Lerp(Left.position.x, Center.position.x - margin - Value, speed * Time.deltaTime);
        RightValue = Mathf.Lerp(Right.position.x, Center.position.x + margin + Value, speed * Time.deltaTime);

        Top.position = new Vector2(Top.position.x, TopValue);
        Bottom.position = new Vector2(Bottom.position.x, BottomValue);

        Left.position = new Vector2(LeftValue, Center.position.y);
        Right.position = new Vector2(RightValue, Center.position.y);



        if (Movement.andando == true && Movement.andando_rapido == true)
        {
            Value = 5;
        }
        if (Movement.andando == true && Movement.andando_rapido == false)
        {
            Value = 2;
        }
        if (Movement.andando == false)
        {
            Value = 0;
        }
    }
}

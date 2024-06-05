using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Roulette : MonoBehaviour
{
    public static Action<int> onRouletteSpinned;
    public float RotatePower;
    public float StopPower;
    public GameObject head;
    private Rigidbody2D rbody;
    int inRotate;
    

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        DisableSelf();
    }

    float t;
    private void Update()
    {           
        
        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower*Time.deltaTime;

            rbody.angularVelocity =  Mathf.Clamp(rbody.angularVelocity, 0 , 1440);
        }

        if(rbody.angularVelocity == 0 && inRotate == 1) 
        {
            t +=1*Time.deltaTime;
            if(t >= 0.5f)
            {
                GetReward();

                inRotate = 0;
                t = 0;
            }
        }
    }


    public void Rotete() 
    {
        if(inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    private void DisableSelf()
    {
        head.SetActive(false);
    }

    public void GetReward()
    {
        float rot = transform.eulerAngles.z;

        if (rot > 0+22 && rot <= 45+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,45);
            Win(2);
        }
        else if (rot > 45+22 && rot <= 90+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,90);
            Win(3);
        }
        else if (rot > 90+22 && rot <= 135+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,135);
            Win(4);
        }
        else if (rot > 135+22 && rot <= 180+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,180);
            Win(5);
        }
        else if (rot > 180+22 && rot <= 225+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,225);
            Win(6);
        }
        else if (rot > 225+22 && rot <= 270+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,270);
            Win(7);
        }
        else if (rot > 270+22 && rot <= 315+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,315);
            Win(8);
        }
        else if (rot > 315+22 && rot <= 360+22)
        {
            GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,0);
            Win(1);
        }

    }


    public void Win(int Score)
    {
        Debug.Log(Score);
        onRouletteSpinned?.Invoke(Score);
        UIManager.instance.ShowDiceRollResult(Score.ToString());
        DisableSelf();
    }


}

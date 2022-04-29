using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject cube;
    public Material material;
    public Image imageLeft;
    public Image imageDown;
    public Image imageRightUp;
    public Text textR;
    public Text textG;
    public Text textB;

    public Slider slider;

    int scoreR;
    int scoreB;
    public int scoreG;

    public bool clickPlus;
    public bool clickMinus;

    bool leftImage;
    bool DownCenter;
    bool RightUp;
    bool cubes;

    bool plus;
    bool minus;

    void Start()
    {

    }

    void Update()
    {
        textR.text = "R: " + scoreR.ToString();
        textB.text = "B: " + scoreB.ToString();
        scoreG = Mathf.RoundToInt(slider.value);
        textG.text = "G: " + scoreG.ToString();

        if (clickPlus == true & scoreR <= 255) 
        {
            scoreR++;
            plus = true;
        }

        if (clickMinus == true & scoreR >= 1) 
        {
            scoreR--;
            minus = true;
        }
        if (leftImage)
        {
            if (minus == true || plus == true)
            {
                imageLeft.GetComponent<Image>().color = new Color(scoreR / 255.0f, scoreG / 255.0f, scoreB / 255.0f);
            }
        }

        if (DownCenter)
        {
            if (minus == true || plus == true)
            {
                imageDown.GetComponent<Image>().color = new Color(scoreR / 255.0f, scoreG / 255.0f, scoreB / 255.0f);
            }
        }

        if (RightUp)
        {
            if (minus == true || plus == true)
            {
                imageRightUp.GetComponent<Image>().color = new Color(scoreR / 255.0f, scoreG / 255.0f, scoreB / 255.0f);
            }
        }

        if (cubes)
        {
            if (minus == true || plus == true)
            {
                material.color = new Color(scoreR / 255.0f, scoreG / 255.0f, scoreB / 255.0f);
            }
        }
    }

    public void DownClickPlus()
    {
        clickPlus = true;
    }

    public void UpClickPlus()
    {
        clickPlus = false;
        
    }

    public void DownClickMinus()
    {    
        clickMinus = true;
    }

    public void UpClickMinus()
    {
        clickMinus = false;
    }

    public void RandomClick()
    {
        scoreB = Random.Range(0, 255);
        plus = true;
    }

    public void ClickImageLeft()
    {
        scoreR = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageLeft.GetComponent<Image>().color.r));
        slider.value = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageLeft.GetComponent<Image>().color.g));
        scoreB = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageLeft.GetComponent<Image>().color.b));
        leftImage = true;
        RightUp = false;
        DownCenter = false;
        cubes = false;
    }

    public void ClickImageDown()
    {
        scoreR = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageDown.GetComponent<Image>().color.r));
        slider.value = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageDown.GetComponent<Image>().color.g));
        scoreB = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageDown.GetComponent<Image>().color.b));
        DownCenter = true;
        leftImage = false;
        RightUp = false;
        cubes = false;
    }

    public void ClickImageUp()
    {
        scoreR = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageRightUp.GetComponent<Image>().color.r));
        slider.value = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageRightUp.GetComponent<Image>().color.g));
        scoreB = Mathf.RoundToInt(Mathf.Lerp(0, 255, imageRightUp.GetComponent<Image>().color.b));
        RightUp = true;
        leftImage = false;
        DownCenter = false;
        cubes = false;
    }

    public void ClickCube()
    {
        scoreR = Mathf.RoundToInt(Mathf.Lerp(0, 255, material.color.r));
        slider.value = Mathf.RoundToInt(Mathf.Lerp(0, 255, material.color.g));
        scoreB = Mathf.RoundToInt(Mathf.Lerp(0, 255, material.color.b));
        cubes = true;
        RightUp = false;
        leftImage = false;
        DownCenter = false;
    }
}





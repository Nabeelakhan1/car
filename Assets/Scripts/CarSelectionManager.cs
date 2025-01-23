using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CarSelectionManager : MonoBehaviour
{
    public List<CarsInfo> carsInfo;

    [Header("Bottom Right Buttons")]
    public GameObject carsBtn;
    public GameObject rimsBtn;
    public GameObject paintBtn;
    public GameObject buyBtn;
    public GameObject drivingBtn;

    [Header("Scroll Bars")]
    public GameObject carsScrollView;
    public GameObject rimsScrollView;
    public GameObject paintScrollView;

    [Header("Car info, Left Top Objects")]

    public Sprite carImg;
    public TextMeshProUGUI carName;
    public TextMeshProUGUI obtainedStageNumber;
    public TextMeshProUGUI totalStageNumber;

    [Header("Car info,Top Speed Objects")]
    public GameObject topSpeedPowerOneImg;
    public GameObject topSpeedPowerTwoImg;
    public TextMeshProUGUI CurrentSpeedTxt;
    public TextMeshProUGUI toBeAddedSpeedTxt;
    public TextMeshProUGUI speedUpgradeAmountTxt;
    
    

    [Header("Car info,acceleration Objects")]
    public GameObject accelerationPowerOneImg;
    public GameObject accelerationPowerTwoImg;
    public TextMeshProUGUI CurrentAccelerationTxt;
    public TextMeshProUGUI toBeAddedAccelerationTxt;
    //public GameObject accelerationPowerUpImg;
    public TextMeshProUGUI accelerationUpgradeAmountTxt;

    [Header("Car info,handling Objects")]
    public GameObject handlingPowerOneImg;
    public GameObject handlingPowerTwoImg;
    public TextMeshProUGUI CurrentHandlingTxt;
    public TextMeshProUGUI toBeAddedHandlingTxt;
    //public GameObject handlingPowerUpImg;
    public TextMeshProUGUI handlingUpgradeAmountTxt;

    [Header("Car info,nitro Objects")]
    public GameObject nitroPowerOneImg;
    public GameObject nitroPowerTwoImg;
    public TextMeshProUGUI CurrentNitroTxt;
    public TextMeshProUGUI toBeAddedNitroTxt;
    //public GameObject nitroPowerUpImg;
    public TextMeshProUGUI nitroUpgradeAmountTxt;

    [Header("Arrays for scrollView Buttons")]
    public Button[] carBtns;
    public Button[] rimBtns;
    public Button[] paintBtns;
    public GameObject[] cars;

    public TextMeshProUGUI totalCash;
    [HideInInspector] public CarsInfo currentCar;
    int currentCarIndex;
    private void Start()
    {
        totalCash.text = PlayerPrefs.GetInt("TotalCash", 1000).ToString();
        currentCarIndex = 0;
        currentCar = carsInfo[currentCarIndex];

       UpdateCarInfo();


        //AdListener for cars
        for (int i = 0; i < carBtns.Length; i++)
            {
            int buttonIndex = i;
            carBtns[buttonIndex].onClick.AddListener(() => ChangeCarInfo(buttonIndex));
            }
    }
    public void ChangeCarInfo(int index)
    {
        currentCarIndex = index;
        currentCar = carsInfo[currentCarIndex];

        UpdateCarInfo();
      
        for (int i = 0; i < carsInfo.Count; i++)
        {
            if (i != currentCarIndex)
            {
                //carsInfo[i].Car.SetActive(false);
                cars[i].SetActive(false);
            }
            else
            {
                cars[i].SetActive(true);
                //carsInfo[i].Car.SetActive(true);

            }
        }
    }
    //to be called on cars Btn 
    public void Cars()
    {
        carsScrollView.SetActive(true);
        rimsScrollView.SetActive(false);
        paintScrollView.SetActive(false);
    }

    //to be called on rims Btn 
    public void Rims()
    {
        carsScrollView.SetActive(false);
        rimsScrollView.SetActive(true);
        paintScrollView.SetActive(false);
    }
    //to be called on buy Btn 
    public void Paint()
    {
        carsScrollView.SetActive(false);
        rimsScrollView.SetActive(false);
        paintScrollView.SetActive(true);
    }

    float toBeAddedacceleration = 100;
    float toBeAddedhandling = 5;
    float toBeAddednitro = 10;
    int toBeAddedSpeed = 100;

    public void UpdateCarInfo()
    {
        CurrentSpeedTxt.text = currentCar.Rcc.maxspeed.ToString();
        float currentAcceleration = currentCar.Rcc.gearShiftUpRPM;
        CurrentAccelerationTxt.text = ((int)(currentAcceleration * 0.2f)).ToString();
        CurrentHandlingTxt.text = currentCar.Rcc.steerAngle.ToString();
        CurrentNitroTxt.text = currentCar.Rcc.turboBoost.ToString();


        toBeAddedSpeedTxt.text = toBeAddedSpeed.ToString();
        toBeAddedAccelerationTxt.text = toBeAddedacceleration.ToString();
        toBeAddedHandlingTxt.text = toBeAddedhandling.ToString();
        toBeAddedNitroTxt.text = toBeAddednitro.ToString();

        speedUpgradeAmountTxt.text=currentCar.speedCashAmount.ToString();
        accelerationUpgradeAmountTxt.text = currentCar.accelerationCashAmount.ToString();
        handlingUpgradeAmountTxt.text = currentCar.handlingCashAmount.ToString();
        nitroUpgradeAmountTxt.text = currentCar.NitroAmount.ToString();
    }
    public void TopSpeedChangerCashBtn()
    {
        if( PlayerPrefs.GetInt("TotalCash")>=currentCar.speedCashAmount) 
        {
            currentCar.Rcc.maxspeed += toBeAddedSpeed;
            toBeAddedSpeed += 100;
            currentCar.speedCashAmount += 200;

            UpdateCarInfo();
        }
    }
    public void AccelerationChangerCashBtn()
    {
        if (PlayerPrefs.GetInt("TotalCash") >= currentCar.accelerationCashAmount)
        {
            currentCar.Rcc.gearShiftUpRPM += toBeAddedacceleration;
            toBeAddedacceleration += 100;
            currentCar.accelerationCashAmount += 200;

            UpdateCarInfo();

        }
    }

    public void HandlingChangerCashBtn()
    {
        if (PlayerPrefs.GetInt("TotalCash") >= currentCar.handlingCashAmount)
        {
            currentCar.Rcc.steerAngle -= toBeAddedhandling;
            toBeAddedhandling += 10;
            currentCar.accelerationCashAmount += 200;

            UpdateCarInfo();

        }
    }
    public void NitroChangerCashBtn()
    {
        if (PlayerPrefs.GetInt("TotalCash") >= currentCar.NitroAmount)
        {
            currentCar.Rcc.turboBoost += toBeAddednitro;
            toBeAddednitro += 10;
            currentCar.NitroAmount += 200;

            UpdateCarInfo();

        }
    }
}

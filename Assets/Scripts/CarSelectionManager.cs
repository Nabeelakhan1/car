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
    public GameObject watchVidBtn;
    public TextMeshProUGUI matPriceText;
    public GameObject matBtnsUI;
    public GameObject carBtnsUI;
    public GameObject rimBtnsUI;


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
    public Color[] carMaterialsColors;
    public int[] MaterialPrices;



    public TextMeshProUGUI totalCash;
    [HideInInspector] public CarsInfo currentCar;
  


    //Indexes 
    int SelectedMaterialindex=0;
    int selectedRimIndex=0;
    int selectedCarIndex;
    private void Start()
    {
        //seting the 1st itme unlocked 
        PlayerPrefs.SetInt(SelectedMaterialindex+ "SelectedMaterialindex", 1);
        SelectedMaterialindex = PlayerPrefs.GetInt("SelectedMaterialindex");

        PlayerPrefs.SetInt(selectedCarIndex + "selectedCarIndex", 1);
        selectedCarIndex = PlayerPrefs.GetInt("selectedCarIndex");

       

        totalCash.text = PlayerPrefs.GetInt("TotalCash", 1000).ToString();
        selectedCarIndex = 0;
        currentCar = carsInfo[selectedCarIndex];

       UpdateCarInfo();
        for(int i = 0; i < carMaterialsColors.Length; i++)
        {
            carsInfo[i].carMaterial.color= carMaterialsColors[i];
        }

        //AddListener to change car Mesh
        for (int i = 0; i < carBtns.Length; i++)
            {
            int buttonIndex = i;
            carBtns[buttonIndex].onClick.AddListener(() => CarMeshChanger(buttonIndex));
            }

        //AddListener to change selected car material
        for (int i = 0; i < paintBtns.Length; i++)
        {
            int buttonIndex = i;
            paintBtns[buttonIndex].onClick.AddListener(() => CarMaterialChanger(buttonIndex));
        }

        //AddListener to change selected car rims
        for(int i=0;i< rimBtns.Length; i++)
        {
            int buttonIndex = i;
            rimBtns[buttonIndex].onClick.AddListener(() => CarRimsChanger(buttonIndex));
        }

    }
    public void UpdateMaterialButtons()
    {
      if(PlayerPrefs.GetInt(SelectedMaterialindex+ "SelectedMaterialindex", 0) == 1)
        {
            buyBtn.SetActive(false);
            drivingBtn.SetActive(true);
            watchVidBtn.SetActive(false);
        }
        else
        {
            matPriceText.text = "$" + MaterialPrices[SelectedMaterialindex];
            buyBtn.SetActive(true);
            drivingBtn.SetActive(false);
        }
    }
    public void CarMeshChanger(int index)
    {
        selectedCarIndex = index;
        currentCar = carsInfo[selectedCarIndex];
        Debug.LogError("the current car is " + selectedCarIndex);
        UpdateCarInfo();
      
        for (int i = 0; i < carsInfo.Count; i++)
        {
            if (i != selectedCarIndex)
            {
                
                cars[i].SetActive(false);
            }
            else
            {
                cars[i].SetActive(true);
              

            }
        }
    }
 

    //
    public void CarMaterialChanger(int indexx)
    {

        SelectedMaterialindex = indexx;
        Color chosenColor = carMaterialsColors[SelectedMaterialindex];

        currentCar.carMaterial.SetColor("_Color", chosenColor);

        UpdateMaterialButtons();


    }
  
    public void CarRimsChanger(int index)
    {
        selectedRimIndex = index;

        RCC_Customization.ChangeWheels(currentCar.Rcc, RCC_ChangableWheels.Instance.wheels[index].wheel,true);
    }

    //to be called on cars Btn 
    public void Cars()
    {
        carsScrollView.SetActive(true);
        rimsScrollView.SetActive(false);
        paintScrollView.SetActive(false);
        matBtnsUI.SetActive(false);
        rimBtnsUI.SetActive(false);
        carBtnsUI.SetActive(true);

    }

    //to be called on rims Btn 
    public void Rims()
    {
        carsScrollView.SetActive(false);
        rimsScrollView.SetActive(true);
        paintScrollView.SetActive(false);
        matBtnsUI.SetActive(false);
        carBtnsUI.SetActive(false);
        rimBtnsUI.SetActive(true);
    }
    //to be called on buy Btn 
    public void Paint()
    {
        Debug.LogError("the selected car is  " + selectedCarIndex);
        carsScrollView.SetActive(false);
        rimsScrollView.SetActive(false);
        paintScrollView.SetActive(true);
        matBtnsUI.SetActive(true);
        carBtnsUI.SetActive(false);
        rimBtnsUI.SetActive(false);
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

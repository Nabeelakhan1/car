using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class CarsInfo 
{


    public RCC_CarControllerV3 Rcc;


    //[Header("Speed Info")]

    //public float currentTopSpeed;
    //public float toBeAddedTopSpeed;
    //public float cashNeededToUpgradeSpeed;

    //[Header("Speed Acceleration")]
    //public float currentAcceleration;
    //public float toBeAddedAcceleration;
    //public float cashNeededToUpgradeAcceleration;

    //[Header("Speed Handling")]
    //public float currentHandling;
    //public float toBeAddedHandling;
    //public float cashNeededToUpgradeHandling;

    //[Header("Speed Nitro")]
    //public float currentNitro;
    //public float toBeAddedNitro;
    //public float cashNeededToUpgradeNitro;

    [Header("Speed stage")]
    public float obtainedStageNumber;
    public float totalStage;

    public int speedCashAmount = 600;
    public int accelerationCashAmount = 300;
    public int handlingCashAmount = 400;
    public int NitroAmount = 500;
    public GameObject Car;

    public string carName;
    public Sprite carImg;
    public int carPrice;

}

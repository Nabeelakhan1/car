using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class CarsInfo 
{
    public RCC_CarControllerV3 Rcc;

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
    public Material carMaterial;

}

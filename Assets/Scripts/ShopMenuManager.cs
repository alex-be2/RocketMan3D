using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject InsufficientFunds;
    [SerializeField] private GameObject BalanceText;
    [SerializeField] private GameObject MainMenuObjects;
    [SerializeField] private GameObject ShopMenuObjects;

    [SerializeField] private TextMeshProUGUI select00;
    [SerializeField] private TextMeshProUGUI select01;
    [SerializeField] private TextMeshProUGUI select02;

    [SerializeField] private Button SelectButton00;
    [SerializeField] private Button SelectButton01;
    [SerializeField] private Button SelectButton02;

    [SerializeField] private Button BuyButton00;
    [SerializeField] private Button BuyButton01;
    [SerializeField] private Button BuyButton02;

    int buyButton00Selected;
    int buyButton01Selected;
    int buyButton02Selected;


    int totalBalance;
    void Start()
    {
        InsufficientFunds.SetActive(false);
        totalBalance = PlayerPrefs.GetInt("PointBalance",0);
        // PlayerPrefs.SetInt("BuyButton00Selected",0);
        // PlayerPrefs.SetInt("BuyButton01Selected",0);
        // PlayerPrefs.SetInt("BuyButton02Selected",0);

        buyButton00Selected = PlayerPrefs.GetInt("BuyButton00Selected",0);
        buyButton01Selected = PlayerPrefs.GetInt("BuyButton01Selected",0);
        buyButton02Selected = PlayerPrefs.GetInt("BuyButton02Selected",0);

        if (buyButton00Selected == 1)
        {
            BuyButton00.interactable = false;
            SelectButton00.interactable = true;
        }
        if (buyButton01Selected == 1)
        {
            BuyButton01.interactable = false;
            SelectButton01.interactable = true;
        }
        if (buyButton02Selected == 1)
        {
            BuyButton02.interactable = false;
            SelectButton02.interactable = true;
        }

        if (PlayerPrefs.GetString("launcherColour") == "red")
        {
            select00.text = "SELECTED";
        }
        else if (PlayerPrefs.GetString("launcherColour") == "blue")
        {
            select01.text = "SELECTED";
        }
        else if (PlayerPrefs.GetString("launcherColour") == "special")
        {
            select02.text = "SELECTED";
        }
    }

    void Update()
    {
        BalanceText.GetComponent<TextMeshProUGUI>().text = Convert.ToString(totalBalance);
    }

    public void Back()
    {
        InsufficientFunds.SetActive(false);
        MainMenuObjects.SetActive(true);
        ShopMenuObjects.SetActive(false);
    }

    public void Default()
    {
        InsufficientFunds.SetActive(false);
        PlayerPrefs.SetString("launcherColour","black");
        select00.text = "SELECT";
        select01.text = "SELECT";
        select02.text = "SELECT";
    }

    public void Buy00()
    {

        totalBalance -= 20000;

        if(totalBalance < 0)
        {
            totalBalance += 20000;
            InsufficientFunds.SetActive(true);
        }
        else
        {
            InsufficientFunds.SetActive(false);
            BuyButton00.interactable = false;
            SelectButton00.interactable = true;
            PlayerPrefs.SetInt("PointBalance", totalBalance);
            PlayerPrefs.SetInt("BuyButton00Selected",1);
            PlayerPrefs.Save();
        }
    }
    public void Buy01()
    {

        totalBalance -= 30000;
        if(totalBalance < 0)
        {
            totalBalance += 30000;
            InsufficientFunds.SetActive(true);
        }
        else
        {
            InsufficientFunds.SetActive(false);
            BuyButton01.interactable = false;
            SelectButton01.interactable = true;
            PlayerPrefs.SetInt("PointBalance", totalBalance);
            PlayerPrefs.SetInt("BuyButton01Selected",1);
            PlayerPrefs.Save();
        }
    }
    public void Buy02()
    {

        totalBalance -= 50000;        
        if(totalBalance < 0)
        {
            totalBalance += 50000;
            InsufficientFunds.SetActive(true);
        }
        else
        {
            InsufficientFunds.SetActive(false);
            BuyButton02.interactable = false;
            SelectButton02.interactable = true;
            PlayerPrefs.SetInt("PointBalance", totalBalance);
            PlayerPrefs.SetInt("BuyButton02Selected",1);
            PlayerPrefs.Save();
        }
    }

    public void SelectOption00()
    {
        InsufficientFunds.SetActive(false);
        select00.text = "SELECTED";
        select01.text = "SELECT";
        select02.text = "SELECT";

        PlayerPrefs.SetString("launcherColour","red");
    }

    public void SelectOption01()
    {
        InsufficientFunds.SetActive(false);
        select00.text = "SELECT";
        select01.text = "SELECTED";
        select02.text = "SELECT";

        PlayerPrefs.SetString("launcherColour","blue");
    }
    public void SelectOption02()
    {
        InsufficientFunds.SetActive(false);
        select00.text = "SELECT";
        select01.text = "SELECT";
        select02.text = "SELECTED";

        PlayerPrefs.SetString("launcherColour","special");
    }


}

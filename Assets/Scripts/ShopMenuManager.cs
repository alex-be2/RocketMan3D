using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuManager : MonoBehaviour
{
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
    void Start()
    {
        
    }

    public void Back()
    {
        Debug.Log("back");
        MainMenuObjects.SetActive(true);
        ShopMenuObjects.SetActive(false);
    }

    public void Buy00()
    {
        BuyButton00.interactable = false;
        SelectButton00.interactable = true;
    }
        public void Buy01()
    {
        BuyButton01.interactable = false;
        SelectButton01.interactable = true;
    }
        public void Buy02()
    {
        BuyButton02.interactable = false;
        SelectButton02.interactable = true;
    }

    public void Select00()
    {
        select00.text = "SELECTED";
        select01.text = "SELECT";
        select02.text = "SELECT";

    }

    public void Select01()
    {
        select00.text = "SELECT";
        select01.text = "SELECTED";
        select02.text = "SELECT";

    }
    public void Select02()
    {
        select00.text = "SELECT";
        select01.text = "SELECT";
        select02.text = "SELECTED";

    }


}

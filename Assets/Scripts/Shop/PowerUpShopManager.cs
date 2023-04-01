using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script handles character shopping actions
public class PowerUpShopManager : MonoBehaviour
{
    private static PowerUpShopManager instance;
    // Start is called before the first frame update
    public PowerUpScObject[] PowerUpItems;
    public static int currentIndex;
    private bool nothingSelected = true;

    private Shop shop;
    private Transform ShopContainer;
    private Transform containerObject;
    private GameObject Button;
    private GameObject PreviewContainerObject;
    private Transform PrevObjTransform;
    //private GameObject PreviewObject;
    void Start()
    {
        ShopContainer = GameObject.FindGameObjectWithTag("ShopContainer").transform;

        for (int i = 0; i < PowerUpItems.Length; i++)
        {
            //CreateButton(PlayerCharacterItems[i]);
            CreateButton2(PowerUpItems[i], i);
        }
        PreviewContainerObject = GameObject.FindGameObjectWithTag("PreviewObject");
    }

    public static PowerUpShopManager GetInstance()
    {
        return instance;
    }

    public static int GetCurrentIndex()
    {
        return currentIndex;
    }

    public PowerUpScObject[] GetPowerUps()
    {
        return PowerUpItems;
    }

    private void Awake()
    {
        instance = this;
    }

    private void CreateButton2(PowerUpScObject characterItem, int index)
    {
        containerObject = GameObject.FindGameObjectWithTag("ShopButtonContainer").transform;
        Button = GameObject.FindGameObjectWithTag("CharacterItem");
        GameObject Item;
        Item = Instantiate(Button) as GameObject;
        Item.transform.SetParent(containerObject);
        //Item.GetComponent<Image>().sprite = characterItem.Artwork;
        Item.transform.localScale = new Vector3(1, 1, 1);
        Item.transform.Find("Text").GetComponent<Text>().text = characterItem.Name;
        Item.transform.Find("ButtomSect").transform.Find("PriceText").GetComponent<Text>().text = characterItem.Price.ToString();
        Item.transform.Find("Artwork").GetComponent<Image>().sprite = characterItem.Artwork;
        Item.GetComponent<Button>().onClick.AddListener(delegate () { ShowItem(index); });

    }

    private void ShowItem(int index)
    {
        nothingSelected = false;
        currentIndex = index;
        UpdateCount(index);
        GameObject PreviewObject;
        PrevObjTransform = PreviewContainerObject.GetComponentInChildren<Transform>();
        //Destroy(PrevObjTransform.gameObject);
        for (var i = PreviewContainerObject.transform.childCount; i-- > 0;)
        {
            Destroy(PreviewContainerObject.transform.GetChild(0).gameObject);
        }
        PreviewObject = Instantiate(PowerUpItems[index].Object);
        PreviewObject.transform.SetParent(PreviewContainerObject.transform);
        //PreviewObject.transform.localScale = new Vector3(1, 1, 1);
        GameObject camera;
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        //camera.transform.LookAt(PreviewObject.transform);
        shop = SaveSystem.LoadShopData();
    }




    // updates the buy and equip button based on if the player has bought the player
    public void UpdateCount(int index)
    {
        Transform shopContainer;
        Transform preview;

        shopContainer = GameObject.FindGameObjectWithTag("ShopContainer").transform;
        preview = shopContainer.Find("TopPlane").Find("MainPanel").Find("Preview").transform;
        shop = SaveSystem.LoadShopData();

        // get how many powerups are in array with index
        int count;
        count = shop.powerups.FindAll(item => item == PowerUpItems[index].Name).Count;
        preview.Find("PowerUpCount").Find("Text").GetComponent<Text>().text = count.ToString();
    }



    public void BuyPowerUp()
    {
        if (nothingSelected)
        {
            return;
        }
        // play sound
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        shop = SaveSystem.LoadShopData();

        //foreach(string name in shop.characters)
        //{
        //    Debug.Log("Character name"+name);
        //}
        var currentIndex = PowerUpShopManager.currentIndex;
        //Debug.Log("current index" + currentIndex);

        var price = PowerUpItems[currentIndex].Price;
        var availableGerms = shop.germs;
        if (availableGerms >= price)
        {
            // update amount of germs
            shop.germs = availableGerms - price;
            shop.powerups.Add(PowerUpItems[currentIndex].Name);
            SaveSystem.SaveShopData(shop);
            ShopContainer.Find("PurchaseOKPop").gameObject.SetActive(true);
        }
        else
        {
            // call the not enough cash popup
            ShopContainer.Find("PurchaseBadPop").gameObject.SetActive(true);

        }

        UpdateCount(currentIndex);
    }

    private void CreateButton(PowerUpScObject characterItem)
    {
        containerObject = GameObject.FindGameObjectWithTag("ShopButtonContainer").transform;
        GameObject button = new GameObject();
        button.transform.SetParent(containerObject);
        button.AddComponent<Button>();
        button.AddComponent<RectTransform>();
        button.AddComponent<Image>();
        button.GetComponent<Image>().sprite = characterItem.Artwork;
    }


    public void BackButton()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("PickShop");
    }

    // Update is called once per frame
    void Update()
    {
        // get the gem count and display on preview
        Transform shopContainer;
        Transform preview;

        shopContainer = GameObject.FindGameObjectWithTag("ShopContainer").transform;
        preview = shopContainer.Find("TopPlane").Find("MainPanel").Find("Preview").transform;
        //Text currentGems;
        preview.Find("CurrentGems").GetComponent<Text>().text = SaveSystem.GetGerms().ToString();

    }





}

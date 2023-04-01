using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{
    
    public static void SaveShopData(Shop shop)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/NUI.bn";
        FileStream stream = new FileStream(path, FileMode.Create);

        //Shop shopData = new Shop();
        //shopData.characters = shop.characters;
        //shopData.powerups = shop.powerups;
        //shopData.highScore = shop.highScore;
        //shopData.germs = shop.germs;

        formatter.Serialize(stream, shop);
        stream.Close();
    }

    public static Shop LoadShopData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/NUI.bn";
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            Shop shop = formatter.Deserialize(stream) as Shop;
            stream.Close();

            return shop;
        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            Shop shopData = new Shop();
            formatter.Serialize(stream, shopData);
            stream.Close();
            return shopData;
        }
    }



    // Other developers can use this to access and update data

    public static int GetGerms()
    {
        Shop shop = LoadShopData();
        return shop.germs;
    }


    public static void SetGems(int gems)
    {
        Shop shop = LoadShopData();
        shop.germs = gems;
        SaveShopData(shop);
    }

    public static int GetHighScore()
    {
        Shop shop = LoadShopData();
        return shop.highScore;
    }

    public static List<string> GetPowerUps()
    {
        Shop shop = LoadShopData();
        return shop.powerups;
    }

    public static void RemovePowerUp(string name)
    {
        Shop shop = LoadShopData();
        shop.powerups.Remove(name);
        SaveShopData(shop);
    }


    public static void SetNewHighScore(int score)
    {
        Shop shop = LoadShopData();
        shop.highScore = score;
        SaveShopData(shop);
    }

    public static void AddPowerUp(string name)
    {
        Shop shop = LoadShopData();
        shop.powerups.Add(name);
        SaveShopData(shop);
    }


    public static int CountPhasing()
    {
        Shop shop = LoadShopData();
        return shop.powerups.FindAll(item => item == "Phase").Count;
    }

    public static int CountSlowmo()
    {
        Shop shop = LoadShopData();
        return shop.powerups.FindAll(item => item == "Slowmo").Count;
    }

    public static int CountBlast()
    {
        Shop shop = LoadShopData();
        return shop.powerups.FindAll(item => item == "Blast").Count;
    }

    public static int CountMagnet()
    {
        Shop shop = LoadShopData();
        return shop.powerups.FindAll(item => item == "Magnet").Count;
    }



    public static void Reset()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/NUI.bn";
        if (File.Exists(path))
        {

            FileStream stream = new FileStream(path, FileMode.Create);
            Shop shop = new Shop();
            formatter.Serialize(stream, shop);
            stream.Close();

        }
        else
        {
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            Shop shopData = new Shop();
            formatter.Serialize(stream, shopData);
            stream.Close();
            
        }

    }


    /// germs
    /// high score
    /// 
}

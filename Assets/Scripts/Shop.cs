using System;
using System.Collections.Generic;


[Serializable]
public class Shop
{
    //! public List<string> characters;
    public List<string> powerups;
    public int germs;
    public int highScore;
    //! public string currentCharacter;


    public Shop()
    {
        //! characters = new List<string>();
        //! characters.Add("Grant");
        powerups = new List<string>();
        germs = 4000;
        highScore = 0;
        //! currentCharacter = "Grant";
    }

    public void SetDefaults()
    {
      

    }
}


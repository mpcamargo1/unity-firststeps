using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{


    public GameObject directionLight;
    private Transform lightTransform;
    int[] topPlayerScore = new int[3];
    List<int> numbers =  new List<int>(){50,15,30};
    Dictionary<string,int> itemInventory = new Dictionary<string,int>()
    {
        {"Potion",5},
        {"Antidote",4},
    };

    // Start is called before the first frame update
    void Start()
    {

        //directionLight = GameObject.Find("Directional Light");
        lightTransform = directionLight.GetComponent<Transform>();
        Debug.Log(lightTransform.localPosition);

        Character hero = new Character("El Tosco");
        Weapon huntingBow = new Weapon("Hunting Bow",105);
        Paladin pld = new Paladin("Paladino",huntingBow);
        pld.PrintStatInfo();
        Weapon warBow = huntingBow;

        warBow.name = "War Bow";
        warBow.damage = 100;

        huntingBow.PrintWeaponInfo();
        warBow.PrintWeaponInfo();


        for(int i =0; i < numbers.Count; i++)
            Debug.LogFormat("Index: {0} = {1}",i,numbers[i]);

        Debug.LogFormat("Quantidade Lista: {0}, Quantidade Dicionário: {1}",numbers.Count, itemInventory.Count);
        Debug.LogFormat("Item Poção {0}", itemInventory["Potion"]);
        itemInventory["Potion"] = 8;
        Debug.LogFormat("Item Poção {0}", itemInventory["Potion"]);
        string characterAction = "Heal";

        switch(characterAction)
        {
            case "Heal":
                Debug.Log("Potion sent.");
                break;
            case "Attack":
                Debug.Log("To Arms!");
                break;
            default:
                Debug.Log("Shields up!");
                break;

        }

        //Debug.Log($"A string can have variables like {firstName} inserted directly!");

    }

        // Update is called once per frame
    void Update()
    {


    }
}

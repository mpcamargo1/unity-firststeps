using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;

public class GameBehaviour : MonoBehaviour, IManager
{
    private string _state;

    public string labelText = "Collect all items !";
    public int maxItems = 1;

    public bool showWinScreen = false;
    public bool showLossScreen = false;

    private int _itemsCollected = 0;
    private int _playerLives = 3;

    public string State
    {
      get { return _state; }
      set { _state = value; }
    }

    void Start()
    {
      Initialize();
      InventoryList<string> inventoryList = new InventoryList<string>();
      inventoryList.SetItem("Potion");
      Debug.Log(inventoryList.item);

    }
    // 5
    public void Initialize()
    {
      _state = "Manager initialized..";
      _state.FancyDebug();
      Debug.Log(_state);

      PlayerBehaviour playerBehaviour = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
      playerBehaviour.playerJump += HandlePlayerJump;

    }

    public void HandlePlayerJump(){
        Debug.Log("Player has jumped...");

    }


    public int Items{
        get{return _itemsCollected;}

        set{
          _itemsCollected = value;
          Debug.LogFormat("Items: {0}",_itemsCollected);

          if(_itemsCollected >= maxItems){
              WinCondition("You've found all the items!",true);
            }
          else{
              labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }

        }

    }

    public int Lives{
      get{return _playerLives;}

      set{
        _playerLives = value;
        if(_playerLives <= 0){
            WinCondition("You want another life with that ?",false);
        }
        else{
          labelText = "Ouch... that's got hurt.";
        }


      }

    }

    void WinCondition(string text,bool win){
      labelText = text;
      if(win)
        showWinScreen = true;
      else
        showLossScreen = true;
      Time.timeScale = 0;
    }


    void OnGUI(){
        // 4
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerLives);
        // 5
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        // 6
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen){
            if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You won")){
                Utilities.RestartLevel(0);
            }

        }
        if(showLossScreen){
          if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"You lose...")){
                Utilities.RestartLevel();
          }
        }

}

}

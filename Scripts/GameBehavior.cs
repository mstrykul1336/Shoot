using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    private int _PaintingsCollected = 0;
    public int maxPaint = 5;
    public bool showWinScreen = false;
    public bool showSecretScreen = false;
    
    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;
            if(_itemsCollected >= maxItems) 
            {
                labelText = "You found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int Paintings
    {
        get { return _PaintingsCollected; }
        set {
            _PaintingsCollected = value;
            if(_PaintingsCollected >= maxPaint) 
            {
                labelText = "You found all the paintings!";
                showSecretScreen = true;
            }
            else
            {
                labelText = "Painting found, only " + (maxPaint - _PaintingsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }
        set {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect (20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect (20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Box(new Rect (20, 80, 150, 25), "Paintings Collected:" + _PaintingsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if(showWinScreen)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 100, 100), "YOU WON!");
            SceneManager.LoadScene(1);
            Time.timeScale = 1.0f;
        }
        if(showSecretScreen)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 100, 100), "YOU SOLVED THE SECRETS!");
            SceneManager.LoadScene(2);
            Time.timeScale = 1.0f;
        }
    }
}

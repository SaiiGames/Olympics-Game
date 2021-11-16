using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatManager : MonoBehaviour
{
    private string[] cheatCode;
    private int index;

    public GameObject cheatConsole;
    private bool isCheating = false;

    public GameObject buildConsole;
    void Start() {
        // Code is "idkfa", user needs to input this in the right order
        cheatCode = new string[] { "c", "h", "e", "a", "t" };
        index = 0;    
    }
 
    void Update() {
        if (!isCheating)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown) {
                // Check if the next key in the code is pressed
                if (Input.GetKeyDown(cheatCode[index])) {
                    // Add 1 to index to check the next key in the code
                    index++;
                }
                // Wrong key entered, we reset code typing
                else {
                    index = 0;    
                }
            }
     
            // If index reaches the length of the cheatCode string, 
            // the entire code was correctly entered
            if (index == cheatCode.Length)
            {
                index = 0;
                isCheating = true;
                Cursor.visible = true;
                cheatConsole.gameObject.SetActive(true);
                Time.timeScale = 0;
            } 
        }
        
    }

    public void OnCheatEnd()
    {
        isCheating = false;
        Cursor.visible = false;
        // buildConsole.gameObject.SetActive(false);
        cheatConsole.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ModifyForce(string _value)
    {
        
        randomForce.limitForce = float.Parse(_value);
        Debug.Log("limitForce"+_value);
    }
    public void ModifySpeed(string _value)
    {
        randomForce.limitSpeed = float.Parse(_value);
        Debug.Log("limitSpeed"+_value);

    }
    public void ModifyMouse(string _value)
    {
        randomForce.mouseModifier = float.Parse(_value);
        Debug.Log("mouseModifier"+_value);

    }

    public void ModifyConsole(bool _value)
    {
        buildConsole.gameObject.SetActive(_value);
    }

    public void SetInfiniteRounds(bool _value)
    {
        RoundManager.isInfiniteRound = true;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
}

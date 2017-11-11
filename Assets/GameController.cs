using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;

    private void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        /* if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) */
        /* Test row wins */
        check3InRow(buttonList[1].text, buttonList[2].text, buttonList[3].text);
        check3InRow(buttonList[0].text, buttonList[4].text, buttonList[8].text);
        check3InRow(buttonList[5].text, buttonList[6].text, buttonList[7].text);

        /* Test column wins */
        check3InRow(buttonList[1].text, buttonList[7].text, buttonList[8].text);
        check3InRow(buttonList[0].text, buttonList[2].text, buttonList[6].text);
        check3InRow(buttonList[3].text, buttonList[4].text, buttonList[5].text);

        /* Test diagnol wins */
        check3InRow(buttonList[0].text, buttonList[1].text, buttonList[5].text);
        check3InRow(buttonList[0].text, buttonList[3].text, buttonList[7].text);

        ChangeSides();
    }

    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void check3InRow(string button1, string button2, string button3)
    {
        if (button1 == button2 && button1 == button3)
        {
            if (playerSide == button1)
            {
                GameOver();
            }
        }

    }
}

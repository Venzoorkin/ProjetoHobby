using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboBuilder : MonoBehaviour
{
    public static PlayerComboBuilder instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }

    public Combo[] BuildCombos()
    {
        string rawText = FileManager.ReadFile("Combos/" + "PlayerComboList");
        if(rawText == null)
        {
            return null;
        }

        List<string> lines = new List<string>(rawText.Split('\n'));

        int comboCount;
        if (!int.TryParse(lines[0], out comboCount))
            return null;

        Combo[] playerCombos;
        playerCombos = new Combo[comboCount];

        Queue<string> stringQueue = new Queue<string>();

        foreach(string L in lines)
        {
            stringQueue.Enqueue(L);
        }
        stringQueue.Dequeue();
        for (int i = 0; i < comboCount; i++)
        {
            playerCombos[i] = new Combo();
            playerCombos[i].directionsQueue = new Queue<Directions>();
            for (int j = 0; j <= stringQueue.Count; j++)
            {
                if (stringQueue.Peek().Contains("IDENTIFIER"))
                {
                    playerCombos[i].comboIdentifier = stringQueue.Dequeue();
                    playerCombos[i].comboIdentifier = playerCombos[i].comboIdentifier.Substring(11);
                }
                else
                {

                    if (stringQueue.Peek().Contains("SKIP") == false)
                    {
                        playerCombos[i].directionsQueue.Enqueue(StringCompare(stringQueue.Dequeue()));
                        Debug.Log(playerCombos[i]);
                    }
                    else
                    {
                        Debug.Log(stringQueue.Dequeue().ToString());
                    }
                }
            }
        }

        return playerCombos;
    }

    Directions StringCompare(string text)
    {
        {
            if (text.Contains("UP_LEFT"))
            {
                return Directions.UP_LEFT;
            }
            else if (text.Contains("UP_RIGHT"))
            {
                return Directions.UP_RIGHT;
            }
            else if (text.Contains("DOWN_LEFT"))
            {
                return Directions.DOWN_LEFT;
            }
            else if (text.Contains("DOWN_RIGHT"))
            {
                return Directions.DOWN_RIGHT;
            }
            else if (text.Contains("UP"))
            {
                return Directions.UP;
            }
            else if (text.Contains("DOWN"))
            {
                return Directions.DOWN;
            }
            else if (text.Contains("LEFT"))
            {
                return Directions.LEFT;
            }
            else if (text.Contains("RIGHT"))
            {
                return Directions.RIGHT;
            }
            else
            {
                Debug.Log("DIRECTION PARSING ERROR");
                return Directions.NEUTRAL;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileManager
{
    private const string COMBO_FOLDER = "Combos/";

    public static string ReadFile(string path)
    {
        TextAsset ta = Resources.Load<TextAsset>(path);

        if (ta == null)
        {
            Debug.Log("TextAsset is NULL !");
        }

        return ta.text;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMD
{
    public static bool isHealess()
    {
        if(Environment.CommandLine.Contains("-batchmode") && Environment.CommandLine.Contains("-nographics"))
        {
            Debug.Log("isHeadless true");
            return true;
        }

        Debug.Log("isHeadless flase");
        return false;
    }
    public static bool TryGetParams(out string value, params string[] args)
    {
        string[] allArgs = Environment.GetCommandLineArgs();
            for (int i = 0;i<allArgs.Length; i++)
                {
            for (int j = 0;j<args.Length; j++)
            {
                if (allArgs[i]==args[j] && i+1 <allArgs.Length)
                {
                    value= allArgs[i+1];
                    return true;
                }
            }
                }
        value = null;
        return false;
    }
}

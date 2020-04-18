using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class dataSaved : MonoBehaviour
{
    string filePath;
   // string deathNum;
    new string[] list = new string[10];

    // Start is called before the first frame update
    void Start()
    {
        filePath = getPath();

    }

    // Update is called once per frame
    void Update()
    {

        //    deathNum = PlayerMvmt.deathStr;
            list[0] = PlayerMvmt.str0;
            list[1] = PlayerMvmt.str1;
            list[2] = PlayerMvmt.str2;
            list[3] = PlayerMvmt.str3;
            list[4] = PlayerMvmt.str4;
            list[5] = PlayerMvmt.str5;
            list[6] = PlayerMvmt.str6;
            list[7] = PlayerMvmt.str7;
            list[8] = PlayerMvmt.str8;
            list[9] = PlayerMvmt.str9;
   
            save();
    }

    void save()
    {


        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine("Level,Movement,Action,Death");

        StringBuilder sb = new StringBuilder();
        StringBuilder sbdeath = new StringBuilder();

        for (int i = 0; i < list.Length; i++)
        {
          //  Debug.Log(list[i]);

            if (list[i] != null)
            {      
                sb.AppendLine(string.Join(",", list[i]));
                writer.WriteLine(sb);
            }

        }

     //   sbdeath.AppendLine(string.Join(",", deathNum));
      //  writer.WriteLine(sbdeath);

        writer.Flush();
        writer.Close();


    }


        string getPath()
        {
            return Application.dataPath + "/" + "Saved.csv";

        }
   
}
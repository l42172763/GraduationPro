using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public static class mytxtIO
{
    private static StreamWriter writer;
    private static StreamReader reader;

    private static List<int> Allmyint = new List<int>();
    private static List<string> Allmystring = new List<string>();
    public static void WriteIntoIntTxt(string message, string txtname)
    {
        char[] datain=message.ToCharArray();
        for(int i=0;i<datain.Length;i++)
        {
            datain[i] = ToSecret(datain[i]);
        }
        message = new string(datain);
        FileInfo file = new FileInfo(Application.dataPath + "/" + AllStatics.CurrentInformation.studentNum + txtname + ".txt");
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            writer = file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }
    public static void WriteIntoStringTxt(string message, string txtname)
    {
        char[] datain = message.ToCharArray();
        for (int i = 0; i < datain.Length; i++)
        {
            datain[i] = ToSecret(datain[i]);
        }
        message = new string(datain);
        FileInfo file = new FileInfo(Application.dataPath + "/" + AllStatics.CurrentInformation.studentNum + txtname + ".txt");
        if (!file.Exists)
        {
            writer = file.CreateText();
        }
        else
        {
            writer = file.AppendText();
        }
        writer.WriteLine(message);
        writer.Flush();
        writer.Dispose();
        writer.Close();
    }
    //读取分数 存储到列表中
    public static void ReadOut(string type,string txtname)
    {
        reader = new StreamReader(Application.dataPath + "/" + AllStatics.CurrentInformation.studentNum + txtname + ".txt", Encoding.UTF8);
        string text;
        switch (type)
        
        {
            case "string":
                Allmystring.Clear();
                while ((text = reader.ReadLine()) != null)
                {
                    char[] datain = text.ToCharArray();
                    for (int i = 0; i < datain.Length; i++)
                    {
                        datain[i] = ToMessage(datain[i]);
                    }
                    text = new string(datain);
                    Allmystring.Add(text);
                }
                break;
            case "int":
                Allmyint.Clear();
                while ((text = reader.ReadLine()) != null)
                {
                    char[] datain = text.ToCharArray();
                    for (int i = 0; i < datain.Length; i++)
                    {
                        datain[i] = ToMessage(datain[i]);
                    }
                    text = new string(datain);
                    Allmyint.Add(int.Parse(text));
                }
                break;
            default:break;
        }
        reader.Dispose();
        reader.Close();
    }
    /// <summary>
    /// 获取从列表读取数据之后的List
    /// </summary>
    /// <returns></returns>
    public static List<int> GetmyIntList(string txtname)
    {
        ReadOut("int", txtname);
        return Allmyint;
    }
    public static List<string> GetmyStringList(string txtname)
    {
        ReadOut("string", txtname);
        return Allmystring;
    }
    private static char ToSecret(char need)
    {
        if (need <= 'z' && need >= 'a')
        {
            need++;
            if (need > 'z') need = 'a';
            return need;
        }
        if (need <= 'Z' && need >= 'A')
        {
            need++;
            if (need > 'Z') need = 'A';
            return need;
        }
        if (need <= '9' && need >= '0')
        {
            need++;
            if (need > '9') need = '0';
            return need;
        }
        return need;
    }
    private static char ToMessage(char need)
    {
        if (need <= 'z' && need >= 'a')
        {
            need--;
            if (need < 'a') need = 'z';
            return need;
        }
        if (need <= 'Z' && need >= 'A')
        {
            need--;
            if (need < 'A') need = 'Z';
            return need;
        }
        if (need <= '9' && need >= '0')
        {
            need--;
            if (need < '0') need = '9';
            return need;
        }
        return need;
    }
}
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
    /*public static void Start(string message, string txtname)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/my" + txtname + ".txt");
        if (file.Exists)
        {
            file.Delete();
            file.Refresh();
        }
    }*/
    //把所有的数据写入文本中
    public static void WriteIntoIntTxt(string message, string txtname)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/my" + txtname + ".txt");
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
        FileInfo file = new FileInfo(Application.dataPath + "/my" + txtname + ".txt");
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
        reader = new StreamReader(Application.dataPath + "/my"+txtname+".txt", Encoding.UTF8);
        string text;
        switch (type)
        
        {
            case "string":
                Allmystring.Clear();
                while ((text = reader.ReadLine()) != null)
                {
                    Allmystring.Add(text);
                }
                break;
            case "int":
                Allmyint.Clear();
                while ((text = reader.ReadLine()) != null)
                {
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

}
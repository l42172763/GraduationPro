using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class mytxtIO : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;

    List<int> Allmyint = new List<int>();
    List<string> Allmystring = new List<string>();
    void Start()
    {
        FileInfo intfile = new FileInfo(Application.dataPath + "/myint.txt");
        if (intfile.Exists)
        {
            intfile.Delete();
            intfile.Refresh();
        }
        else intfile.Create();
        FileInfo stringfile = new FileInfo(Application.dataPath + "/mystring.txt");
        if (stringfile.Exists)
        {
            stringfile.Delete();
            stringfile.Refresh();
        }
        else stringfile.Create();
    }
    //把所有的数据写入文本中
    public void WriteIntoIntTxt(string message)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/myint.txt");
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
    public void WriteIntoStringTxt(string message)
    {
        FileInfo file = new FileInfo(Application.dataPath + "/mystring.txt");
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
    public void ReadOutInt()
    {
        Allmyint.Clear();
        reader = new StreamReader(Application.dataPath + "/myint.txt", Encoding.UTF8);
        string text;
        while ((text = reader.ReadLine()) != null)
        {
            Allmyint.Add(int.Parse(text));
        }
        reader.Dispose();
        reader.Close();
    }
    public void ReadOutString()
    {
        Allmyint.Clear();
        reader = new StreamReader(Application.dataPath + "/mystring.txt", Encoding.UTF8);
        string text;
        while ((text = reader.ReadLine()) != null)
        {
            Allmystring.Add(text);
        }
        reader.Dispose();
        reader.Close();
    }
    /// <summary>
    /// 获取从列表读取数据之后的List
    /// </summary>
    /// <returns></returns>
    public List<int> GetmyIntList()
    {
        ReadOutInt();
        return Allmyint;
    }
    public List<string> GetmyStringList()
    {
        ReadOutString();
        return Allmystring;
    }

}
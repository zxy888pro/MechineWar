using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;

public class CommonApi
{

    public static string Charset = "UTF-8";

    public static string GetString(byte[] data, string charset = "")
    {
        string str = "";
        try
        {
            if (charset == "")
            {
                str = Encoding.Default.GetString(data);
            }
            else
            {
                str = Encoding.GetEncoding(charset).GetString(data);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
        return str;
    }

    public static void CopyDirectory(string srcPath, string destPath)
    {
        try
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)
                {
                    if (!Directory.Exists(destPath + "\\" + i.Name))
                    {
                        Directory.CreateDirectory(destPath + "\\" + i.Name);
                    }
                    CopyDirectory(i.FullName, destPath + "\\" + i.Name);
                }
                else
                {
                    if (!i.FullName.EndsWith(".meta"))
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);
                    }

                }
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }


}

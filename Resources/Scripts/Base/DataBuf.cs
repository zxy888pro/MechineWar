using System;
using System.Collections.Generic;

public class DataBuffer
{

    List<byte> byteList = new List<byte>();
    int cursor = 0;

    public byte[] Array
    {
        get
        {
            return byteList.ToArray();
        }
    }

    public int Size
    {
        get
        {
            return byteList.Count;
        }
    }

    public DataBuffer()
    {
    }

    public DataBuffer(byte[] data)
    {
        if (data != null)
        {
            byteList.AddRange(data);
        }
    }

    public void MoveCursor(int n)
    {
        cursor += n;
    }
    public void Reset()
    {
        cursor = 0;
    }

    public void Clear()
    {
        cursor = 0;
        byteList.Clear();
    }

    public byte ReadByte()
    {
        byte ret = byteList[cursor];
        MoveCursor(1);

        return ret;
    }

    public short ReadShort()
    {
        short ret = BitConverter.ToInt16(byteList.ToArray(), cursor);
        MoveCursor(2);

        return ret;
    }

    public int ReadInt()
    {
        int ret = BitConverter.ToInt32(byteList.ToArray(), cursor);
        MoveCursor(4);

        return ret;
    }

    public long ReadLong()
    {
        long ret = BitConverter.ToInt64(byteList.ToArray(), cursor);
        MoveCursor(8);

        return ret;
    }

    public float ReadFloat()
    {
        float ret = BitConverter.ToSingle(byteList.ToArray(), cursor);
        MoveCursor(4);

        return ret;
    }

    public double ReadDouble()
    {
        double ret = BitConverter.ToDouble(byteList.ToArray(), cursor);
        MoveCursor(8);

        return ret;
    }

    public string ReadString()
    {
        int len = ReadInt();

        string s = "";
        for (int i = 0; i < len; i++)
            s += (char)ReadByte();

        return s;
    }

    public void WriteByte(short b) { WriteByte((byte)b); }
    public void WriteByte(int b) { WriteByte((byte)b); }
    public void WriteByte(byte b)
    {
        byteList.Add(b);
    }

    public void WriteShort(int s) { WriteShort((short)s); }
    public void WriteShort(short s)
    {
        byteList.AddRange(BitConverter.GetBytes(s));
    }

    public void WriteInt(int i)
    {
        byteList.AddRange(BitConverter.GetBytes(i));
    }

    public void WriteLong(long l)
    {
        byteList.AddRange(BitConverter.GetBytes(l));
    }

    public void WriteFloat(float f)
    {
        byteList.AddRange(BitConverter.GetBytes(f));
    }

    public void WriteDouble(double d)
    {
        byteList.AddRange(BitConverter.GetBytes(d));
    }

    public void WriteString(string s)
    {
        WriteInt(s.Length);
        for (int i = 0; i < s.Length; i++)
            WriteByte((byte)s[i]);
    }
}

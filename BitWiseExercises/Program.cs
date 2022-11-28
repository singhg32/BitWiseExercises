using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Text;

Debug.Assert(text.Powerof2(32) == true);
Debug.Assert(text.Powerof2(17) == false);
Debug.Assert(text.Kernighan(32) == 1);
Debug.Assert(text.Kernighan(81) == 3);
Debug.Assert(text.Kernighan(-1) == 32);
Debug.Assert(text.Kernighan(32) == 1);


class text
{
    static List<bool> inttolist(int input)
    {
        List<bool> booleans = new List<bool>();
        for (int p = 0; p < 32; ++p)
        {
            int v = 1 << p;
            bool b = (input & v) == v;
            booleans.Add(b);
        }
        booleans.Reverse();
        return booleans;
    }

    static int paritybit(int input)
    {
        throw new NotImplementedException();
    }

    //3. write a bitwise function that determines if a number is a power of 2 (or 4? or 8?) 
    public static bool Powerof2(int input)
    {
        bool b = false;
        for (int p = 0; p < 32; ++p)
        {
            int v = 1 << p;
            b = (input | v) == v;
            if (b)
                break;
        }
        return b;
    }
    public static bool Powerof4(int input)
    {
        bool b = false;
        for (int p = 0; p < 32; p += 2)
        {
            int v = 1 << p;
            b = (input | v) == v;
            if (b)
                break;
        }
        return b;
    }

    public static bool Powerof8(int input)
    {
        bool b = false;
        for (int p = 0; p < 32; p+= 3)
        {
            int v = 1 << p;
            b = (input | v) == v;
            if (b)
                break;
        }
        return b;
    }
    //4. count the number of set bits(i.e. 1s) using Brian Kernighan's n & (n-1) algorithm 

    public static int Kernighan(int input)
    {
        int count = 0;
        while (input != 0)
        {
            input = input & (input - 1);
            count++;
        }
        return count;
    }

    //5. implement a function that performs the Vernam Cipher on two given strings; consider the creation of a keystream and show that(x ^ y) ^ y == x.
    public static string Vernham(string plain, string key, Encoding encoding)
    {
        byte[] plaintext = encoding.GetBytes(plain);
        byte[] bitkey = encoding.GetBytes(key);
        string total = "";
        for (int i = 0; i < plaintext.Length; i++)
        {
            int currentbit = plaintext[i] ^ bitkey[i];
            total += currentbit.ToString();
        }
        return total;
    }

}

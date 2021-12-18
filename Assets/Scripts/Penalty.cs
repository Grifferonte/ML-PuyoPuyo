using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penalty : MonoBehaviour
{
    [Header("Penalty zones")]
    [SerializeField] GameObject PenaltyZone1;
    [SerializeField] GameObject PenaltyZone2;
    [Header("Prefab of token")]
    [SerializeField] GameObject singletoken;
    [SerializeField] GameObject linetoken;

    public static int penaltycounter1=0;
    public static int penaltycounter2=0;
    public static GameObject penaltyzone1;
    public static GameObject penaltyzone2;
    public static GameObject single;
    public static GameObject line;

    private void Awake()
    {
        penaltyzone1 = PenaltyZone1;
        penaltyzone2 = PenaltyZone2;
        single = singletoken;
        line = linetoken;

    }
    public static void penaltylineset()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 12; y > 0; y--)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    GameMaster.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate(0 + (x - 3) * 48, 312 - ((12 - y + 1) * 48));
                }
            }
        }
    }
    public static void penaltylineset2()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 12; y > 0; y--)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    GameMaster2.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate2(0 + (x - 3) * 48, 312 - ((12 - y + 1) * 48));
                }
            }
        }
    }
    public static void penaltysinglesset(int number)
    {
        bool[] colluns = new bool[6];
        for (int i = 0; i < colluns.Length; i++) colluns[i] = false;
        int r;
       for (int i = 0; i < number; i++)
        {
            r = Random.Range(0, 6);
            while (colluns[r])
            {
                r = Random.Range(0, 6);
            }
            colluns[r] = true;
        }
       for (int x=0; x < colluns.Length; x++)
        {
            if (colluns[x])
            {
                for (int y = 12; y > 0; y--)
                {
                    if (GameMaster.puyoArr[x, y] != null)
                    {
                        GameMaster.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate(0 + (x - 3) * 48, 312 - ((12 - y + 1) * 48));
                    }
                }
            }
        }
    }
    public static void penaltysinglesset2(int number)
    {
        bool[] colluns = new bool[6];
        for (int i = 0; i < colluns.Length; i++) colluns[i] = false;
        int r;
        for (int i = 0; i < number; i++)
        {
            r = Random.Range(0, 6);
            while (colluns[r])
            {
                r = Random.Range(0, 6);
            }
            colluns[r] = true;
        }
        for (int x = 0; x < colluns.Length; x++)
        {
            if (colluns[x])
            {
                for (int y = 12; y > 0; y--)
                {
                    if (GameMaster2.puyoArr[x, y] != null)
                    {
                        GameMaster2.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate2(0 + (x - 3) * 48, 312 - ((12 - y + 1) * 48));
                    }
                }
            }
        }
    }
    public static void penaltyzone1add(int number)
    {
        penaltycounter1 += number;
        int stock = penaltycounter1;
        int nbelement = 0;
        if (penaltyzone1.transform.childCount > 0)
        {
            foreach (Transform child in penaltyzone1.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        while (stock > 0)
        {
            GameObject newtokenObj;
            if (stock > 6)
            {
                newtokenObj = Instantiate(line);
                stock -= 6;
            }
            else
            {
                newtokenObj = Instantiate(single);
                stock -= 1;
            }
            newtokenObj.transform.SetParent(penaltyzone1.transform);
            newtokenObj.transform.localPosition = new Vector3(0 + nbelement * 37, 0, 0);
            newtokenObj.transform.localScale = new Vector3(1, 1, 1);
            nbelement++;
        }
    }
        public static void penaltyzone2add(int number)
        {
            penaltycounter2 += number;
            int stock = penaltycounter2;
            int nbelement = 0;
        if (penaltyzone2.transform.childCount > 0)
        {
            foreach (Transform child in penaltyzone2.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        while (stock > 0)
            {
                GameObject newtokenObj;
                if (stock >= 6)
                {
                    newtokenObj = Instantiate(line);
                    stock -= 6;
                }
                else
                {
                    newtokenObj = Instantiate(single);
                    stock -= 1;
                }
                newtokenObj.transform.SetParent(penaltyzone2.transform);
                newtokenObj.transform.localPosition = new Vector3(0 + nbelement * 37, 0, 0);
                newtokenObj.transform.localScale = new Vector3(1, 1, 1);
                nbelement++;
            }
        }
    public static void setgraypuyo()
    {
        if (penaltyzone1.transform.childCount > 0) {
        foreach (Transform child in penaltyzone1.transform)
        {
            GameObject.Destroy(child.gameObject);
        } }
        while (penaltycounter1 > 0)
        {
            if (penaltycounter1 >= 6)
            {
                penaltylineset();
                penaltycounter1 -= 6;
            }
            else
            {
                penaltysinglesset(penaltycounter1);
                penaltycounter1 = 0;
            }
        }
    } 
    public static void setgraypuyo2()
    {
        if (penaltyzone2.transform.childCount > 0)
        {
            foreach (Transform child in penaltyzone2.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        while (penaltycounter2 > 0)
        {
            if (penaltycounter2 >= 6)
            {
                penaltylineset2();
                penaltycounter2 -= 6;
            }
            else
            {
                penaltysinglesset2(penaltycounter1);
                penaltycounter2 = 0;
            }
        }
    }

}

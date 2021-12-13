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

    private int penaltycounter1=0;
    private int penaltycounter2=0;
    private GameObject penaltyzone1;
    private GameObject penaltyzone2;
    private GameObject single;
    private GameObject line;

    private void Awake()
    {
        penaltyzone1 = PenaltyZone1;
        penaltyzone2 = PenaltyZone2;
        single = singletoken;
        line = linetoken;

    }
    public void penaltylineset()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 12; y++)
            {
                if (GameMaster.puyoArr[x, y] != null)
                {
                    GameMaster.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate(x, y + 1);
                }
            }
        }
    }
    public void penaltylineset2()
    {
        for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 12; y++)
            {
                if (GameMaster2.puyoArr[x, y] != null)
                {
                    GameMaster2.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate2(x, y + 1);
                }
            }
        }
    }
    public void penaltysinglesset(int number)
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
                for (int y = 0; y < 12; y++)
                {
                    if (GameMaster.puyoArr[x, y] != null)
                    {
                        GameMaster.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate(x, y + 1);
                    }
                }
            }
        }
    }
    public void penaltysinglesset2(int number)
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
                for (int y = 0; y < 12; y++)
                {
                    if (GameMaster2.puyoArr[x, y] != null)
                    {
                        GameMaster2.puyoArr[x, y + 1] = PuyoCreater.Graypuyocreate2(x, y + 1);
                    }
                }
            }
        }
    }
    public void penaltyzone1add(int number)
    {
        penaltycounter1 += number;
        int stock = penaltycounter1;
        int nbelement = 0;
        foreach (Transform child in penaltyzone1.transform)
        {
            GameObject.Destroy(child.gameObject);
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
        public void penaltyzone2add(int number)
        {
            penaltycounter2 += number;
            int stock = penaltycounter2;
            int nbelement = 0;
            foreach (Transform child in penaltyzone2.transform)
            {
                GameObject.Destroy(child.gameObject);
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
    public void setgraypuyo()
    {
        foreach (Transform child in penaltyzone1.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
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
    public void setgraypuyo2()
    {
        foreach (Transform child in penaltyzone2.transform)
        {
            GameObject.Destroy(child.gameObject);
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

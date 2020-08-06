using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class CollectibleController : MonoBehaviour
{
    public Vector3 value;
    public float mWait;
    public float wait;
    public float lWait;
    public bool stop;
    public int sWait;
    public GameObject[] collectibles;
    public int collectiblecount;
    int randomcollectible;
    public TextMesh str;
    public int length;
    public int countpal;
    private static int pl;
    private string rs;
    private int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wSpawn());
        str = GameObject.Find("Pick Up").GetComponentInChildren<TextMesh>();
        str.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        wait = Random.Range(lWait, mWait);
        pl = Random.Range(3, 10);
        randomstring();
    }

    public void randomstring()
    {
        int number;
        countpal = 0;


        number = Random.Range(0, 2);
        rs = "";

        string[] ch = new string[] { "x", "s", "0" };
        if (counter >= 7)
        {
            str.text = CreatePal(ch);
            countpal = countpal + 1;

        }
        else
        {
            if (number == 0)
            {
                str.text = CreatePal(ch);
                countpal = countpal + 1;


            }
            else
            {
                counter++;

                str.text = CreateRanStr(ch);
            }
        }
    }

    IEnumerator wSpawn()
    {
        yield return new WaitForSeconds(sWait);

        while (collectiblecount < 10)
        {


            randomcollectible = Random.Range(0, 2);

            Vector3 positionofSpawn = new Vector3(Random.Range(-value.x, value.x), 0, Random.Range(-value.z, value.z));
            Instantiate(collectibles[randomcollectible], positionofSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(wait);
            collectiblecount = collectiblecount + 1;
        }
    }

    string CreateRanStr(string[] st)
    {
        rs = "";

        length = Random.Range(9, 15);

        for (int s = 0; s < length; s++)
        {
            rs = rs + st[Random.Range(0, st.Length)];
        }
        str.color = Color.black;

        return rs;

    }
    string CreatePal(string[] st)
    {
        rs = "";

        length = Random.Range(9, 15);

        for (int s = 0; s < length / 2; s++)
        {
            rs = rs + st[Random.Range(0, st.Length)];
        }
        rs = rs + new string(rs.Reverse().ToArray());
        str.color = Color.white;


        return "x" + rs + "x";

    }

}

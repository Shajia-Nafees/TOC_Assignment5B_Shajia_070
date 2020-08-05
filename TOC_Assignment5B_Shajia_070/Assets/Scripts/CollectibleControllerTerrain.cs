using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CollectibleControllerTerrain : MonoBehaviour
{
   GameObject randomCube;

    Vector3 position;
    static string[] validandnotvalids = new string[70];
    static public System.Random rdom = new System.Random();
    public static Random rdm = new Random();
    private static System.Random newrandom = new System.Random();


    void Start()
    {
        randomCube = GameObject.FindGameObjectWithTag("PickUp");
        string balanced_bracket, not_balanced_bracket;
        int balanced_PickUp = 0;
        int not_balanced_PickUp = 0;
        while (not_balanced_PickUp <= 49)
        {


            not_balanced_bracket = RandomText(rdom.Next(9, 15));
            if (!IsBalanced(not_balanced_bracket))
            {
                
                position = new Vector3(Random.Range(-10, 230f), 6f, Random.Range(10, 220));
                GameObject newobject;
                newobject = Instantiate(randomCube, position, Quaternion.identity);
                newobject.GetComponent<CText>().nameLable.text = not_balanced_bracket;
                not_balanced_PickUp++;


            }
        }
        while (balanced_PickUp <= 21)
        {


            balanced_bracket = RandomText(rdom.Next(9, 15));
            if (IsBalanced(balanced_bracket))
            {

                 position = new Vector3(Random.Range(-10, 230f), 6f, Random.Range(10, 220));
                GameObject newobject;
                newobject = Instantiate(randomCube, position, Quaternion.identity);
                newobject.GetComponent<CText>().nameLable.text = balanced_bracket;
                balanced_PickUp++;
                

            }
        }
        randomCube.active = false;
    }

    public static string RandomText(int length)
    {
        const string chars = "xs0()";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[newrandom.Next(s.Length)]).ToArray());
    }

    public static bool IsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' },
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            
            foreach (char c in input)
            {
               
                if (bracketPairs.Keys.Contains(c))
                {
                    
                    brackets.Push(c);
                }
                else
                    
                    if (bracketPairs.Values.Contains(c))
                {
                    
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        
                        return false;
                }
                else
                   
                    continue;
            }
        }
        catch
        {
           
            return false;
        }

        
        return brackets.Count() == 0 ? true : false;
    }
}

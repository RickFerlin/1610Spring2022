
using UnityEngine;

public class VariablesAndFunctions : MonoBehaviour
{
    private int myInt = 5;


    void Start()
    {
        myInt = MultiplyByTwo(myInt);
    }


    int MultiplyByTwo(int number)
    {
        int result;
        result = number * 2;
        return result;
    }
}
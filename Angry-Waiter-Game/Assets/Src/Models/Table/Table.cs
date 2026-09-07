using UnityEngine;

public class Table : MonoBehaviour
{
    private const int chairPosOffset = 5;


    GoodCustomer tableOwner;

    public void initialize()
    {
        tableOwner = null;
    }
    public void sit(GoodCustomer customer)
    {
        tableOwner = customer;
    }
}

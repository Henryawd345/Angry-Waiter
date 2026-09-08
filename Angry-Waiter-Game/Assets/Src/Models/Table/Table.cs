using NUnit.Framework;
using UnityEngine;

public class Table : MonoBehaviour
{
    private Transform chairTrainsform;
    private Transform tableExitTransform;


    GoodCustomer tableOwner;
    Transform tableOwnerTransform;
    public bool isReserved {get; private set;}

    public void initialize()
    {
        tableOwner = null;
        isReserved = false;
    }
    public void reserve(GoodCustomer customer, Transform customerTransform)
    {
        if (!isReserved)
            isReserved = true;

        tableOwner = customer;
        tableOwnerTransform = customerTransform;
    }
    public void sit()
    {
        tableOwnerTransform = chairTrainsform;
    }
    public void standUp(GoodCustomer customer)
    {
        if (tableOwner != customer)
            return;

        if (tableOwnerTransform != null)
            tableOwnerTransform = tableExitTransform;

        tableOwner = null;
        tableOwnerTransform = null;

        isReserved = false;
    }
    public void cancleReservedTable(GoodCustomer customer)
    {
        if (tableOwner != customer)
            return;

        
    }
}

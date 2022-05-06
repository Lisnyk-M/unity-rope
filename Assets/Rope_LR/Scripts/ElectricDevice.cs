using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact
{
    public float potential;
    public ElectricDevice target;
    public int connectedContact;
}
public abstract class ElectricDevice : MonoBehaviour
{
    public Contact[] _contacts;
    //public Contact firstContact;
    //public Contact secondContact;
    public float current;
    public float resistance;
    public abstract void Connect(ElectricDevice target, int selfContact, int targetContact);
    public abstract void Disconnect(ElectricDevice target, int selfContact);
    public abstract void Transporting();
}

public class Wire : ElectricDevice
{
    public override void Connect(ElectricDevice target, int selfContact, int targetContact)
    {
        _contacts[selfContact].target = target;
        _contacts[selfContact].connectedContact = targetContact;
        //switch (selfContact)
        //{
        //    case 0:
        //        firstContact.target = target;
        //        firstContact.connectedContact = targetContact;
        //        break;
        //    case 1:
        //        secondContact.target = target;
        //        secondContact.connectedContact = targetContact;
        //        break;
        //}

    }
    public override void Disconnect(ElectricDevice target, int selfContact)
    {

    }

    public override void Transporting()
    {
        float potential0 = _contacts[0].target._contacts[_contacts[0].connectedContact].potential;
        float potential1 = _contacts[1].target._contacts[_contacts[1].connectedContact].potential;
        float potential = (Mathf.Abs(potential0) > Mathf.Abs(potential1)) ? potential0 : potential1;
        _contacts[0].potential = potential;
        _contacts[1].potential = potential;
    }
}

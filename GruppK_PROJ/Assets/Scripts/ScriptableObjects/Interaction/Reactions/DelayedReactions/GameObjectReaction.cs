using UnityEngine;

public class GameObjectReaction : DelayedReaction
{
    public GameObject gameObject;
    public bool activeState;
    private DayNightButton list;

    protected override void SpecificInit()
    {
      //  list = GameObject.FindGameObjectWithTag("LightsList").GetComponent<StaffObjectContainer>();
    }

    protected override void ImmediateReaction()
    {
        gameObject.SetActive (activeState);
        if (activeState == false)
        {

        }
    }

    public void RemoveObjectFromList(GameObject o)
    {
       
    }

}
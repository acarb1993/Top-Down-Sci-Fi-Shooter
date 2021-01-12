using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int biomassCount;
    void Start()
    {
        biomassCount = 0;
    }

    public void addToBiomass()
    {
        biomassCount++;
        Debug.Log(biomassCount);
    }
}

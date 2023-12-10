using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Death : CoreComponent
{
    private Stats Stats => stats ? stats : core.GetComponent<Stats>();
    private Stats stats;

       public void Die()
       {
           core.transform.parent.gameObject.SetActive(false);
       }

    private void OnEnable()
    {
        Stats.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        Stats.OnHealthZero -= Die;
    }
}

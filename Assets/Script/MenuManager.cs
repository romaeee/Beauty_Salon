using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   public void Done()
    {
        Spawn.done = true;
    }

    public void Delite()
    {
        PlayerPrefs.DeleteAll();
    }
}

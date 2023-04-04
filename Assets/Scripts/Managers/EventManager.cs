using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Singleton

    public static EventManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public delegate void OnObjectThrown(items heldObject);
    public OnObjectThrown onObjectThrown;
}

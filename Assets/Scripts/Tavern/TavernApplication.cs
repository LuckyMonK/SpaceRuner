using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernElement : MonoBehaviour {
    public TavernApplication app;
}
public class TavernApplication : MonoBehaviour
{
    public TavernModel TavernModel;
    public TavernView TavernView;
    public TavernController TavernController;
}

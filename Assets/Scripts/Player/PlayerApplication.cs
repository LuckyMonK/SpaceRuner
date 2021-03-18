using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElement : MonoBehaviour {
    public PlayerApplication app;
}
public class PlayerApplication : MonoBehaviour
{
    public PlayerModel PlayerModel;
    public PlayerView PlayerView;
    public PlayerController PlayerController;
}

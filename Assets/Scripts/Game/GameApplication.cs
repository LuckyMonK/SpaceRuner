using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement : MonoBehaviour {
    public GameApplication app;
}
public class GameApplication : MonoBehaviour
{
    public GameModel PlayerModel;
    public GameView PlayerView;
    public GameController PlayerController;
}

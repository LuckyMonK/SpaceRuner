using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelElement : MonoBehaviour {
    public LevelApplication app;
}

public class LevelApplication  : MonoBehaviour
{
    public LevelModel LevelModel;
    public LevelView LevelView;
    public LevelController LevelController;
}

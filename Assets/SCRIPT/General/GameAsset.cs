using UnityEngine;

public class GameAsset : MonoBehaviour
{
    public static GameAsset _i;
    public static GameAsset i
    {
        get
        {
            if (_i == null)
            {
                _i = (Instantiate(Resources.Load("GameAsset")) as GameObject).GetComponent<GameAsset>();
            }
            return _i;
        }
    }
    public GameObject bgBtn;
}

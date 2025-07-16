using System.Collections;
using DG.Tweening;
using UnityEngine;

public enum RoadType
{
    switchtype, rotatetype
};


public class Road : MonoBehaviour
{
    public RoadType roadType;

  
    void Start()
{
    if (roadType == RoadType.rotatetype)
    {
        // Y축을 따라 360도 만큼 1초에 한 바퀴, 끝나면 다시 반복, 선형 속도
        transform
            .DORotate(new Vector3(0, 0, 360), 3f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }
}
}

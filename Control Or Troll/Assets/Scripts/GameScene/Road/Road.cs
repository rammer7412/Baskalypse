using System.Collections;
using DG.Tweening;
using UnityEngine;

public enum RoadType
{
    switchtype, rotatetype, statictype
};


public class Road : MonoBehaviour
{
    public RoadType roadType;

    [SerializeField] private float rotateDuration = 3f;
    [SerializeField] private float switchDuration = 3f;
    [SerializeField] private float switchRange = 5f;


    void Start()
    {
        if (roadType == RoadType.rotatetype)
        {
            // Y축을 따라 360도 만큼 1초에 한 바퀴, 끝나면 다시 반복, 선형 속도
            transform
                .DORotate(new Vector3(0, 0, 360), rotateDuration, RotateMode.LocalAxisAdd)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }
        else if (roadType == RoadType.switchtype)
        {
            // 왔다가 갔다가 반복
            transform
                .DOMoveX(switchRange, switchDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }
    }
}

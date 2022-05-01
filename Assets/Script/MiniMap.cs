using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] Transform Player;

    private void LateUpdate()
    {
        Vector3 Pos = Player.position;
        Pos.y = transform.position.y;
        transform.position = Pos;

        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }

}

using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : NetworkBehaviour
{
    public struct CubeInput : INetworkInput
    {
        public const byte A = 0x01;
        public uint AKey;
        public uint BKey;
        public const uint B = 1;
    }
    public override void FixedUpdateNetwork()
    {
        base.FixedUpdateNetwork();
        if (GetInput<CubeInput>().HasValue)
        {
            var dataInput = GetInput<CubeInput>().Value;
            if (dataInput.AKey != 0x00)
            {
                transform.position += Vector3.left;
            }
            if (dataInput.BKey == 0x02)
            {
                transform .position += Vector3.right;
            }
        }
    }

    public override void Spawned()
    {
        base.Spawned();
    }
}

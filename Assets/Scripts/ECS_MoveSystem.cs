using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Transforms;
using Unity.Entities;
using Unity.Jobs;

public struct ICD_MoveSpeed : IComponentData
{
    public float MoveSpeed;
}

public class ECS_MoveSystem : JobComponentSystem {

	private struct MoveJob : IJobProcessComponentData<ICD_MoveSpeed, Position>
    {
        public float DeltaTime;

        public void Execute(ref ICD_MoveSpeed speed, ref Position pos)
        {
            pos.Value.y -= speed.MoveSpeed * DeltaTime;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var Job = new MoveJob
        {
            DeltaTime = Time.deltaTime
        };

        return Job.Schedule(this, 64, inputDeps);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Jobs;

public struct ICD_RotationSpeed : IComponentData
{
    public float RotationSpeed;
}

public class ECS_RotatationSystem : JobComponentSystem
{

    private struct RotationJob : IJobProcessComponentData<ICD_RotationSpeed, Rotation>
    {
        public float DeltaTime;

        public void Execute(ref ICD_RotationSpeed speed, ref Rotation rot)
        {
            rot.Value = math.mul(math.normalize(rot.Value), math.axisAngle(math.up(), speed.RotationSpeed * DeltaTime));
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var Job = new RotationJob
        {
            DeltaTime = Time.deltaTime
        };

        return Job.Schedule(this, 64, inputDeps);
    }
}

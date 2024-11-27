using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct BuildingUpdateJob : IJobParallelFor
{
    public NativeArray<Building.Data> BuildingDataArray;

    public void Execute(int index)
    {
        Building.Data buildingData = BuildingDataArray[index];
        buildingData.UpdatePowerUsage();
        BuildingDataArray[index] = buildingData;
    }
}

public class Building : MonoBehaviour
{
    [SerializeField]
    private int _floors;

    public struct Data
    {
        private int _tenants;
        private Unity.Mathematics.Random _random;

        public float PowerUsage { get; private set; }

        public Data(Building building)
        {
            _random = new(1);
            _tenants = building._floors * _random.NextInt(50,200);

            PowerUsage = 0;
        }

        public void UpdatePowerUsage()
        {
            PowerUsage = 0f;

            for (int i = 0; i < _tenants; i++)
            {
                PowerUsage += _random.NextFloat(1f, 5f);
            }
        }
    }
}

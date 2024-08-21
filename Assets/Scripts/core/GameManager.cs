using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        InitializeAllComponentSystems();
    }

    private void InitializeAllComponentSystems()
    {
        // �������� ��� ����, ������� ����������� �� ComponentSystem
        var systemTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => t.IsSubclassOf(typeof(ComponentSystem)) && !t.IsAbstract);

        foreach (var type in systemTypes)
        {
            // ������� ��������� ������� ���������� ����
            ComponentSystem system = (ComponentSystem)Activator.CreateInstance(type);
            system.Initialize();
        }
    }
}

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
        // Получаем все типы, которые наследуются от ComponentSystem
        var systemTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => t.IsSubclassOf(typeof(ComponentSystem)) && !t.IsAbstract);

        foreach (var type in systemTypes)
        {
            // Создаем экземпляр каждого найденного типа
            ComponentSystem system = (ComponentSystem)Activator.CreateInstance(type);
            system.Initialize();
        }
    }
}

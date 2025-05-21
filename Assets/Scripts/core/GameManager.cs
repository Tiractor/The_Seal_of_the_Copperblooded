using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public bool Debugging = false;
        private int _tickTimer = -1;
        private Dictionary<Type, ComponentSystem> _systems = new();
        public PrefabContainer Prefabs;
        private void Awake()
        {
            if(instance == null) instance = this;
            else DestroyImmediate(gameObject);
            InitializeAllComponentSystems();
        }

        private void FixedUpdate()
        {
            _tickTimer += 1;
            if (_tickTimer % 5 == 0) SystemsTickUpdate();
            if (_tickTimer >= 50)
            {
                SystemsSecondUpdate();
                _tickTimer = 0;
            }
        }
        private void SystemsSecondUpdate()
        {
            foreach (var system in _systems.Values)
            {
                system.SecondUpdate();
            }
        }
        private void SystemsTickUpdate()
        {
            foreach (var system in _systems.Values)
            {
                system.TickUpdate();
            }
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
                _systems.Add(type, system);
            }
        }
        public TypeSystem tryGetSystem<TypeSystem>()
            where TypeSystem : ComponentSystem
        {
            if (_systems.TryGetValue(typeof(TypeSystem), out var system) && system is TypeSystem specificSystem)
            {
                return specificSystem;
            }

            return null;
        }
        public static TypeSystem TryGetSystem<TypeSystem>()
            where TypeSystem : ComponentSystem
        {
            return instance != null ? instance.tryGetSystem<TypeSystem>() : null;
        }
    }
}
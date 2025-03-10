using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;
using Core.Mind;

namespace Core.Game 
{ 
    public class ButtonsBind : EntitySystem
    {
        public struct Bind 
        {
            public Type type;
            public string name;
        }

        private static Dictionary<KeyCode, Bind> Binds; 
        public override void Initialize()
        {
            Subscribe<PlayerComponent, ButtonPressEvent>(OnButtonPress);
        }
        void OnButtonPress(PlayerComponent playerComponent, ButtonPressEvent args) 
        {
            if (Binds.TryGetValue(args.Button, out var bind))
            {
                // Получаем метод TriggerEvent с использованием рефлексии
                var method = typeof(EntitySystem).GetMethod(nameof(TriggerEvent), BindingFlags.Static | BindingFlags.Public);
                var genericMethod = method.MakeGenericMethod(bind.type);

                // Вызываем метод TriggerEvent<T>(playerComponent.gameObject, args)
                genericMethod.Invoke(null, new object[] { playerComponent.gameObject, args });
            }
        }
    }
}

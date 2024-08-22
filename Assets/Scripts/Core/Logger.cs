using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public static class Logger
    {
        public static void Info(object message)
        {
            Output("<color=green>[INFO]</color> ", message);
        }
        public static void Warn(object message)
        {
            Output("<color=yellow>[WARN]</color> ", message);
        }
        public static void Error(object message)
        {
            Output("<color=red>[ERRO]</color> ", message);
        }
        private static void Output(string tag, object message)
        {
            string output = message.ToString();
            if (message is Dictionary<string, Single> dictionary)
            {
                output = Output(tag, dictionary);
            }
            Debug.Log(tag + Time.fixedTime + " second from Start\n" + output );
        }

        private static string Output<T>(string tag, T message)
            where T : Dictionary<string, Single>
        {
            string output = "";
            foreach (var cur in message)
            {
                output += cur.Key + " : " + cur.Value + "\n";
            }
            return output;
        }
    }
}
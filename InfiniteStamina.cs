using System;
using HarmonyLib;
using BepInEx;
using UnityEngine;
using BepInEx.Logging;
using System.Reflection;

namespace InfiniteStamina
{
    [BepInPlugin("cocco.CWTRY", "infinite stamina", "1.0.0")]
    

    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("infinite stamina");
        internal ManualLogSource mls;
        void Awake()
        {
            mls = BepInEx.Logging.Logger.CreateLogSource("infinite stamina");
            mls.LogWarning("this is a warning bro and it's working goodd");
            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(CurrentStaminaPatch));
        }

    }
    [HarmonyPatch(typeof(PlayerController))]
    internal class CurrentStaminaPatch { 
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void infiniteStamina(ref PlayerController __instance)
        {
            FieldInfo playerField = typeof(PlayerController).GetField("player", BindingFlags.NonPublic | BindingFlags.Instance);
            Player player = (Player)playerField.GetValue(__instance);

            if (player != null)
            {
                // Imposta la stamina del giocatore su un valore desiderato (es. 10f)
                player.data.currentStamina = 10f;
            }
        }
        
    }
    }


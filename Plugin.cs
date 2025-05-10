using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using HarmonyLib;

namespace TutorialMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Tutorial : BaseUnityPlugin
    {
        private const string modGUID = "zx.LCoop";
        private const string modName = "LCoop";
        private const string modVersion = "1.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        void Awake()
        {
            var registrador = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            registrador.LogMessage(modName + " carregou com sucesso");

            harmony.PatchAll(typeof(Tutorial));
            harmony.PatchAll(typeof(Lan));
        }
    }
}


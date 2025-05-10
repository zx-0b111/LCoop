using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Unity.Netcode.Transports.UTP;
using Unity.Netcode;


namespace TutorialMod
{
    [HarmonyPatch(typeof(MenuManager))]
    [HarmonyPatch(("StartAClient"))]
    
    public class Lan
    {
        const ushort porta = 7777;
        
        
        [HarmonyPrefix]

        static void Prefix()
        {
            using (StreamReader sr = new StreamReader("BepInEx\\plugins\\LConf.txt"))
            {
                string ip = sr.ReadLine();
                var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
                transport.SetConnectionData(ip, porta);

                Console.WriteLine(ip);
            }
        }
    }
}

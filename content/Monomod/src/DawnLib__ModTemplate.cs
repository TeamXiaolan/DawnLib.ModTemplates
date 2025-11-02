using BepInEx;
using BepInEx.Logging;
using System.Reflection;
#if (MMHOOKLocation == "")
using System.Collections.Generic;
using MonoMod.RuntimeDetour;
#endif
using UnityEngine;
using Dawn;
using Dawn.Utils;
#if (UseDusk == true)
using Dusk;
#endif

namespace DawnLib._ModTemplate;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(DawnLib.PLUGIN_GUID)]
public class DawnLib__ModTemplate : BaseUnityPlugin
{
    internal new static ManualLogSource Logger { get; private set; } = null!;

    internal static PersistentDataContainer PersistentData { get; private set; } = null!;

#if (UseDusk == true)
    public static DuskMod Mod { get; private set; } = null!;
#endif

    private void Awake()
    {
        Logger = base.Logger;

        // Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID) // uncomment if using Harmony to patch

#if (UseDusk == true)
        // Setup Dusk
        AssetBundle mainBundle = AssetBundleUtils.LoadBundle(Assembly.GetExecutingAssembly(), "main_bundle");
        Mod = DuskMod.RegisterMod(this, mainBundle);
        Mod.RegisterContentHandlers();
#endif

        // Example Persistent Data Container Usage
        // You can do anything you want with this DataContainer, there are a few additonal ones under the DawnLib class that pertain to actual save files
        PersistentData = this.GetPersistentDataContainer();

        // e.g. track the last version the player played with, could be useful if you want do to stuff like setting migration.
        // if you want to do config migration you should use DawnLib.GetCurrentInstallSave instead.
        PersistentData.Set(DawnLib__ModTemplateKeys.LastVersion, MyPluginInfo.PLUGIN_VERSION);

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }
}

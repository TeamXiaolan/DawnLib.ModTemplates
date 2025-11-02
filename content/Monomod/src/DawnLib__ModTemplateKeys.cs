using Dawn;

namespace DawnLib._ModTemplate;

// NamespacedKeys are a big component of how DawnLib works and tracks information,
// therefore you'll end up using quite a few of them
//
// To keep things organised, it's best practice to keep all your keys within a static class like this.
// So instead of doing NamespacedKey.From anywhere in your plugin, you should do it here.
// This way you only create one, and if you want to refactor the name to something, it's much easier.
// 
// If you contain lots of keys, you might want to use child classes e.g: DawnLib__ModTemplateKeys.Items.MyItem
// Note: the use of `partial` here is because of the DawnLib SourceGenerator, which you might not be using.
public static partial class DawnLib__ModTemplateKeys {
    // You may want to update this namespace. It should be "Snake case", e.g: FacilityMeltdown's namespace should be `facility_meltdown`
    // You can also shorten it if you want, e.g: `meltdown`
    public const string Namespace = "{DawnNamespace}";

    // Data Keys
    internal static NamespacedKey LastVersion = NamespacedKey.From(Namespace, "last_version");
}
using UnityEngine;

public static class GameData
{
    public static string SelectedSkin {
        get {
            if (!IsSkinPurchased("Coil Voltic Black")) {
                AddPurchasedSkin("Coil Voltic Black");
                PlayerPrefs.SetString("LastSelectedSkin", "Coil Voltic Black");
            }
            return PlayerPrefs.GetString("LastSelectedSkin");
        }
        set {
            PlayerPrefs.SetString("LastSelectedSkin", value);
        }
    }

    public static int Balance {
        get {
            return PlayerPrefs.GetInt("Balance");
        }
        set {
            PlayerPrefs.SetInt("Balance", value);
            PlayerPrefs.Save();
        }
    }

    public static void AddPurchasedSkin(string skinName) {
        if (!IsSkinPurchased(skinName)) {
            PlayerPrefs.SetInt($"Skin_{skinName}", 1);
            PlayerPrefs.Save();
        }
    }

    public static bool IsSkinPurchased(string skinName) {
        return PlayerPrefs.GetInt($"Skin_{skinName}", 0) == 1;
    }
}

namespace DangerCity
{
  /// <summary>
  /// Add component menu constants
  /// </summary>
  public static class ACC
  {
    public const string PROJECT_MENU = "DangerCity/";
    public const string BOOT_MENU = PROJECT_MENU + "Boot/";
    public const string VIEW_MENU = PROJECT_MENU + "Views/";
    public const string SERVICES_MENU = PROJECT_MENU + "Services/";

    public static class Names
    {
      public const string LEVEL_INSTALLER = BOOT_MENU + "Level Installer";
      public const string PROJECT_INSTALLER = BOOT_MENU + "Project Installer";

      public const string LAMP_VIEW = VIEW_MENU + "Lamp View";
      public const string COINS_VIEW = VIEW_MENU + "Coins View";
      public const string HERO_VIEW = VIEW_MENU + "Hero View";
      public const string CAMERA_VIEW = VIEW_MENU + "Camera View";
      public const string TELEPORT = VIEW_MENU + "Teleport";
      public const string COIN_VIEW = VIEW_MENU + "Coin View";
      public const string MAIN_COIN_VIEW = VIEW_MENU + "Main Coin View";

      public const string HERO_DETECTOR = SERVICES_MENU + "Hero Detector";
      public const string NEXT_SCENE_LOADER = SERVICES_MENU + "Next Scene Loader";
      public const string HERO_INTERACTION_DETECTOR = SERVICES_MENU + "Hero Interaction Detector";
      public const string DEATH_ACTIVATOR = SERVICES_MENU + "Death Activator";
      public const string LADDER = VIEW_MENU + "Ladder";
      public const string HORIZONTAL_LADDER = VIEW_MENU + "Horizontal Ladder";
    }
  }
}